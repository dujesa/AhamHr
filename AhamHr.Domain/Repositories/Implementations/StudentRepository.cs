using AhamHr.Data.Entities;
using AhamHr.Data.Entities.Models;
using AhamHr.Data.Enums;
using AhamHr.Domain.Abstractions;
using AhamHr.Domain.Helpers;
using AhamHr.Domain.Models.ViewModels.Account;
using AhamHr.Domain.Repositories.Interfaces;
using AhamHr.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Implementations
{
    public class StudentRepository : UserRepository, IStudentRepository
    {
        public StudentRepository(AhamHrContext dbContext, IClaimProvider claimProvider) : base(dbContext, claimProvider)
        {
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
