using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Data.Entities.Models
{
    public class Student : User
    {
        public ICollection<StudentAppointment> StudentAppointments { get; set; }
    }
}
