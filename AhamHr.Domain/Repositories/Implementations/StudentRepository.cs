using AhamHr.Data.Entities;
using AhamHr.Data.Entities.Models;
using AhamHr.Data.Enums;
using AhamHr.Domain.Abstractions;
using AhamHr.Domain.Helpers;
using AhamHr.Domain.Models.ViewModels.Account;
using AhamHr.Domain.Models.ViewModels.Student;
using AhamHr.Domain.Repositories.Interfaces;
using AhamHr.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Implementations
{
    public class StudentRepository : UserRepository, IStudentRepository
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public StudentRepository(AhamHrContext dbContext, IClaimProvider claimProvider, IAppointmentRepository appointmentRepository) : base(dbContext, claimProvider)
        {
            _appointmentRepository = appointmentRepository;
        }

        public StudentProfileModel GetProfile()
        {
            var studentId = _claimProvider.GetUserId();

            var appointmentsOfStudent = _appointmentRepository.GetAllForAuthenticatedStudent();

            return _dbContext.Students
                .Include(s => s.StudentAppointments.Where(sa => sa.StudentId == studentId))
                .Select(s => new StudentProfileModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    Appointments = appointmentsOfStudent,
                })
                .FirstOrDefault();
        }

        public ResponseResult<Student> RegisterStudent(RegistrationModel registrationModel)
        {
            var encryptedPassword = EncryptionHelper.Hash(registrationModel.Password);
            var student = new Student
            {
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                Email = registrationModel.Email,
                EncryptedPassword = encryptedPassword,
                PhoneNumber = registrationModel.PhoneNumber,
                UserRole = UserRole.Student,
            };

            _dbContext.Add(student);
            _dbContext.SaveChanges();

            return new ResponseResult<Student>(student);
        }
    }
}
