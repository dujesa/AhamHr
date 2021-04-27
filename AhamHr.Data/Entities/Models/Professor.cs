using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Data.Entities.Models
{
    public class Professor : User
    {
        public string PhotoPath { get; set; }
        public decimal? Rating { get; set; }
        public string Address { get; set; }
        public bool IsVerified { get; set; } = false;
        public int MaxStudentsAppointmentCapacity { get; set; } = 1;
        public ICollection<AvailableTermin> AvailableTermins { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<ProfessorSubject> ProfessorSubjects { get; set; }
    }
}
