using AhamHr.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Models.ViewModels.Appointment
{
    public class AppointmentCreateModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Literature { get; set; }
        public string Comment { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public int ProfessorId { get; set; }
    }
}
