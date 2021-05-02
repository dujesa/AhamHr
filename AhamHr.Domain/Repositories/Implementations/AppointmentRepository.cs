using AhamHr.Data.Entities;
using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Abstractions;
using AhamHr.Domain.Models.ViewModels.Appointment;
using AhamHr.Domain.Models.ViewModels.Professor;
using AhamHr.Domain.Repositories.Interfaces;
using AhamHr.Domain.Services.Implementations;
using AhamHr.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AhamHrContext _dbContext;
        private readonly IClaimProvider _claimProvider;
        public AppointmentRepository(AhamHrContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }

        public async Task<ResponseResult<Appointment>> Create(AppointmentCreateModel model)
        {
            var professor = await _dbContext.Professors.FindAsync(model.ProfessorId);

            var appointment = new Appointment
            { 
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Literature = model.Literature,
                Comment = model.Comment,
                AppointmentType = model.AppointmentType,
                Professor = professor,
            };

            await _dbContext.AddAsync(appointment);
            await _dbContext.SaveChangesAsync();

            var studentId = _claimProvider.GetUserId();
            var student = await _dbContext.Students.FindAsync(studentId);

            var studentAppointment = new StudentAppointment
            {
                Appointment = appointment,
                Student = student,
            };

            await _dbContext.AddAsync(studentAppointment);
            await _dbContext.SaveChangesAsync();

            return new ResponseResult<Appointment>(appointment);
        }

        public ICollection<AppointmentInfoModel> GetAllForAuthenticatedStudent()
        {
            var studentId = _claimProvider.GetUserId();
            
            return _dbContext.Appointments
                .Include(a => a.StudentAppointments.Where(sa => sa.StudentId == studentId))
                .Include(a => a.Professor)
                .Select(a => new AppointmentInfoModel
                {
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    Literature = a.Literature,
                    Professor = a.Professor == null ?
                        null :
                        new ProfessorInfoModel
                        {
                            Id = a.Professor.Id,
                            FirstName = a.Professor.FirstName,
                            LastName = a.Professor.LastName,
                            Rating = a.Professor.Rating ?? 0,
                        },
                })
                .ToList();
        }
    }
}
