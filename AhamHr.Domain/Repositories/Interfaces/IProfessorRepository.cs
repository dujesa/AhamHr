using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Abstractions;
using AhamHr.Domain.Models.ViewModels.Professor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Interfaces
{
    public interface IProfessorRepository : IUserRepository
    {
        public ResponseResult<Professor> RegisterProfessor(ProfessorRegistrationModel registrationModel);
    }
}
