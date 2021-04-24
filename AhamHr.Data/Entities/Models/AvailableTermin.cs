using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Data.Entities.Models
{
    public class AvailableTermin
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime RecurringUntil { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
