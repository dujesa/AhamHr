using AhamHr.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Data.Entities.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
    }
}
