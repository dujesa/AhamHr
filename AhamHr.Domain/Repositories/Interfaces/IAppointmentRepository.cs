using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Abstractions;
using AhamHr.Domain.Models.ViewModels.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        public Task<ResponseResult<Appointment>> Create(AppointmentCreateModel model);
        public ICollection<AppointmentInfoModel> GetAllForAuthenticatedStudent();
    }
}
