using AhamHr.Domain.Constants;
using AhamHr.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Services.Implementations
{
    public class ClaimProvider : IClaimProvider
    {
        public ClaimProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public int GetUserId()
        {
            var userIdString = _httpContextAccessor.HttpContext.User.FindFirst(Claims.UserId).Value;
            var isSuccessful = int.TryParse(userIdString, out var userId);
            if (!isSuccessful)
                throw new AuthenticationException("Claim does not exist!");

            return userId;
        }
    }
}
