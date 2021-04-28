using AhamHr.Domain.Models.ViewModels.Account;
using AhamHr.Domain.Models.ViewModels.Professor;
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
    public class ProfessorController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IJwtService _jwtService;

        public ProfessorController(IUserRepository userRepository, IProfessorRepository professorRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _professorRepository = professorRepository;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(RegisterProfessor))]
        public ActionResult<string> RegisterProfessor(ProfessorRegistrationModel registrationModel)
        {
            var checkEmailResponse = _userRepository.CheckEmail(registrationModel.Email);
            if (checkEmailResponse.IsError)
                return BadRequest(checkEmailResponse.Message);

            var registerProfessorResponse = _professorRepository.RegisterProfessor(registrationModel);
            if (registerProfessorResponse.IsError)
                return BadRequest(registerProfessorResponse.Message);

            var token = _jwtService.GetJwtTokenForUser(registerProfessorResponse.Data);
            return Ok(token);
        }  
        
        [AllowAnonymous]
        [HttpGet(nameof(GetAllProfessorsBySubjects))]
        public ActionResult<string> GetAllProfessorsBySubjects([FromQuery]ProfessorFilterModel filterModel)
        {
            var filteredProfessors = _professorRepository.GetFilteredProfessors(filterModel);
            return Ok(filteredProfessors);
        }
    }
}
