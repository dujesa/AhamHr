using AhamHr.Data.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Data.Entities.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Literature { get; set; }
        public string ReceiptPath { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public LocationType LocationType { get; set; }
        public int? ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public ICollection<StudentAppointment> StudentAppointments { get; set; }
    }
}
