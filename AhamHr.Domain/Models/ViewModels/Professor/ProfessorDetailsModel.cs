using AhamHr.Domain.Models.ViewModels.AvailableTermin;
using AhamHr.Domain.Models.ViewModels.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Models.ViewModels.Professor
{
    public class ProfessorDetailsModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Rating { get; set; }
        public ICollection<AvailableTerminModel> AvailableTermins { get; set; }
        public ICollection<SubjectModel> Subjects { get; set; }
    }
}
