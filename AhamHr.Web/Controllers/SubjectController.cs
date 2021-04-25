using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Repositories.Interfaces;
using AhamHr.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhamHr.Web.Controllers
{
    public class SubjectController : ApiController
    {
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        private readonly ISubjectRepository _subjectRepository;

        [HttpGet(nameof(GetAllSubjects))]
        public IActionResult GetAllSubjects()
        {
            return Ok(_subjectRepository.GetAllSubjects());
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpPost(nameof(AddSubject))]
        public IActionResult AddSubject(Subject subjectToAdd)
        {
            var wasAddSuccessful = _subjectRepository.AddSubject(subjectToAdd);
            if (wasAddSuccessful)
                return Ok();
            return Forbid();
           
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpPost(nameof(EditSubject))]
        public IActionResult EditSubject(Subject edittedSubject)
        {
            var wasEditSucessful = _subjectRepository.EditSubject(edittedSubject);
            if (wasEditSucessful)
                return Ok();
            return NotFound();
        }
        
        [Authorize(Policy = Policies.Admin)]
        [HttpDelete(nameof(DeleteSubject))]
        public IActionResult DeleteSubject([FromRoute] int id)
        {
            var wasDeleteSucessful = _subjectRepository.DeleteSubject(id);
            if (wasDeleteSucessful)
                return Ok();
            return Forbid();
        }

        [HttpGet(nameof(GetSubjectById))]
        public IActionResult GetSubjectById(int id)
        {
            var subject = _subjectRepository.GetSubjectById(id);
            if (subject != null)
                return Ok(subject);
            return NotFound();
        }
    }
}
