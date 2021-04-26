using AhamHr.Domain.Models.ViewModels.Account;
using AhamHr.Domain.Repositories.Interfaces;
using AhamHr.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhamHr.Web.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IJwtService _jwtService;

        public AccountController(IUserRepository userRepository, IProfessorRepository professorRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _professorRepository = professorRepository;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<string> Login(CredentialsModel credentialsModel)
        {
            var result = _userRepository.GetUserIfValidCredentials(credentialsModel);
            if (result.IsError)
                return BadRequest(result.Message);

            var user = result.Data;
            var token = _jwtService.GetJwtTokenForUser(user);
            return Ok(token);
        }
    }
}
