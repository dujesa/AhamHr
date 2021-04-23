using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Data.Entities.Models
{
    public class StudentAppointment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
