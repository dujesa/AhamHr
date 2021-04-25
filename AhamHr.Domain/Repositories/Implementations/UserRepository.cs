using AhamHr.Data.Entities;
using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Repositories.Interfaces;
using AhamHr.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(AhamHrContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }
        private readonly AhamHrContext _dbContext;
        private readonly IClaimProvider _claimProvider;


        public User GetUser(int userId)
        {
            return _dbContext.Users.Find(userId);
        }
    }
}
