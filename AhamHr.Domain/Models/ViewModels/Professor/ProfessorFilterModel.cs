using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Models.ViewModels.Professor
{
    public class ProfessorFilterModel
    {
        public ICollection<int> SubjectIds { get; set; } = new List<int>();
        public decimal MinimalRating { get; set; } = 0;
    }
}
