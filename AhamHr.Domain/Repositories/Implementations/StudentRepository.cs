using AhamHr.Data.Entities;
using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Abstractions;
using AhamHr.Domain.Helpers;
using AhamHr.Domain.Models.ViewModels.Account;
using AhamHr.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AhamHrContext _dbContext;
        public StudentRepository(AhamHrContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseResult<Student> RegisterStudent(RegistrationModel registrationModel)
        {
            var encryptedPassword = EncryptionHelper.Hash(registrationModel.Password);
            var student = new Student
            {
                Email = registrationModel.Email,
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                EncryptedPassword = encryptedPassword,
            };

            _dbContext.Add(student);
            _dbContext.SaveChanges();

            return new ResponseResult<Student>(student);
        }
    }
}
