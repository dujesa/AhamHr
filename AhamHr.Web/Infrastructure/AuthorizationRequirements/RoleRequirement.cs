using AhamHr.Data.Enums;
using Microsoft.AspNetCore.Authorization;

namespace AhamHr.Web.Infrastructure.AuthorizationRequirements
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public UserRole Role { get; set; }

        public RoleRequirement(UserRole role)
        {
            Role = role;
        }
    }
}
