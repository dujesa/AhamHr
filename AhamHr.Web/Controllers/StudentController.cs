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
    public class StudentController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IJwtService _jwtService;

        public StudentController(IUserRepository userRepository, IStudentRepository studentRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(RegisterStudent))]
        public ActionResult<string> RegisterStudent(RegistrationModel registrationModel)
        {
            var checkEmailResponse = _userRepository.CheckEmail(registrationModel.Email);
            if (checkEmailResponse.IsError)
                return BadRequest(checkEmailResponse.Message);

            var registerStudentResponse = _studentRepository.RegisterStudent(registrationModel);
            if (registerStudentResponse.IsError)
                return BadRequest(registerStudentResponse.Message);

            var token = _jwtService.GetJwtTokenForUser(registerStudentResponse.Data);
            return Ok(token);
        }
    }
}
