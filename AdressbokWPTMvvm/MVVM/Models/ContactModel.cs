using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressbokWPTMvvm.MVVM.Models
{
    public class ContactModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Number { get; set; } = null!;


        public string DisplayName => $"{FirstName} {LastName}";
    }
}
