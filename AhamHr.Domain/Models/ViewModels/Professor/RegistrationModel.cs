using AhamHr.Domain.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Models.ViewModels.Professor
{
    public class ProfessorRegistrationModel : RegistrationModel
    {
        public string PhotoPath { get; set; }
        public string Address { get; set; }
    }
}
