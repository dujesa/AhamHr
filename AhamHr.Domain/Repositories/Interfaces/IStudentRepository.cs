using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Abstractions;
using AhamHr.Domain.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Interfaces
{
    public interface IStudentRepository : IUserRepository
    {
        public ResponseResult<Student> RegisterStudent(RegistrationModel registrationModel);
    }
}
