using AhamHr.Data.Entities;
using AhamHr.Data.Entities.Models;
using AhamHr.Data.Enums;
using AhamHr.Domain.Abstractions;
using AhamHr.Domain.Helpers;
using AhamHr.Domain.Models.ViewModels.Professor;
using AhamHr.Domain.Repositories.Interfaces;
using AhamHr.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Implementations
{
    public class ProfessorRepository : UserRepository, IProfessorRepository
    {
        public ProfessorRepository(AhamHrContext dbContext, IClaimProvider claimProvider) : base(dbContext, claimProvider)
        {
        }

        public ResponseResult<Professor> RegisterProfessor(ProfessorRegistrationModel registrationModel)
        {
            var encryptedPassword = EncryptionHelper.Hash(registrationModel.Password);
            var professor = new Professor
            {
                Email = registrationModel.Email,
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                EncryptedPassword = encryptedPassword,
                PhoneNumber = registrationModel.PhoneNumber,
                Address = registrationModel.Address,
                PhotoPath = registrationModel.PhotoPath,
                UserRole = UserRole.Professor,
            };

            _dbContext.Add(professor);
            _dbContext.SaveChanges();

            return new ResponseResult<Professor>(professor);
        }
    }
}
