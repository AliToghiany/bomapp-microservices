using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Contacts.Commands.NewContact
{
    public class CreateNewContactCommand
    {
        public string? Phone { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
    }
}
