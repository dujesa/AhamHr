using AhamHr.Domain.Models.ViewModels.Appointment;
using AhamHr.Domain.Repositories.Interfaces;
using AhamHr.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhamHr.Web.Controllers
{
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IProfessorRepository _professorRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository, IProfessorRepository professorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _professorRepository = professorRepository;
        }

        [Authorize(Policy = Policies.Student)]
        [HttpPost(nameof(Create))]
        public async Task<ActionResult> Create(AppointmentCreateModel model)
        {
            var result = await _appointmentRepository.Create(model);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data.Id);
        }

        [Authorize]
        [HttpGet(nameof(GetAllForAuthenticatedStudent))]
        public ActionResult<string> GetAllForAuthenticatedStudent()
        {
            var appointments = _appointmentRepository.GetAllForAuthenticatedStudent();
            if (appointments != null)
                return Ok(appointments);
            return NotFound();
        }
    }
}
