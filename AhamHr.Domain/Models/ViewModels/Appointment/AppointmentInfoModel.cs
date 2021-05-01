using AhamHr.Data.Enums;
using AhamHr.Domain.Models.ViewModels.Professor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Models.ViewModels.Appointment
{
    public class AppointmentInfoModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Literature { get; set; }
        public ProfessorInfoModel Professor { get; set; }
        //public ICollection<StudentInfoModel> Subjects { get; set; }

    }
}
