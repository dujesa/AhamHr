using AhamHr.Data.Entities;
using AhamHr.Data.Entities.Models;
using AhamHr.Data.Enums;
using AhamHr.Domain.Abstractions;
using AhamHr.Domain.Helpers;
using AhamHr.Domain.Models.ViewModels.AvailableTermin;
using AhamHr.Domain.Models.ViewModels.Professor;
using AhamHr.Domain.Models.ViewModels.Subject;
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

        public ICollection<ProfessorInfoModel> GetFilteredProfessors(ProfessorFilterModel filterModel)
        {
            var filteredProfessors = _dbContext.Professors
                .Where(p => p.Rating >= filterModel.MinimalRating);

            if (filterModel.SubjectIds.Any())
            {
                filteredProfessors = filteredProfessors
                    .Include(p => p.ProfessorSubjects.Where(
                        ps => filterModel.SubjectIds.Contains(ps.SubjectId))
                    )
                    .Where(p => p.ProfessorSubjects.Count > 0);
            }

            return filteredProfessors
                .Select(p => new ProfessorInfoModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Rating = p.Rating ?? 0,
                })
                .ToList();
        }

        public ProfessorDetailsModel GetProfessorById(int id)
        {
            var professorAvailableTermins = _dbContext.AvailableTermins
                .Where(at => at.ProfessorId == id)
                .Select(at => new AvailableTerminModel 
                {
                    Id = at.Id,
                    StartTime = at.StartTime,
                    EndTime = at.EndTime,
                })
                .ToList();

            var professorSubjects = _dbContext.Subjects
                .Include(s => s.ProfessorSubjects.Where(ps => ps.ProfessorId == id))
                .Select(s => new SubjectModel
                { 
                    Name = s.Name,
                })
                .ToList();

            return _dbContext.Professors
                .Where(p => p.Id == id)
                .Select(p => new ProfessorDetailsModel
                { 
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Rating = p.Rating ?? 0,
                    AvailableTermins = professorAvailableTermins,
                    Subjects = professorSubjects
                })
                .FirstOrDefault();
        }
    }
}
