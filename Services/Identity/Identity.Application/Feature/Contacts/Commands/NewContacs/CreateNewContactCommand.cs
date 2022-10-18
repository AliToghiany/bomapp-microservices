using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Contacts.Commands.NewContacs
{
    public class CreateNewContactCommand:IRequest<List<ContactResponse>>
    {
       public List<NewContactRequest> NewContactRequests { get; set; }
        public long UserId { get; set; }
    }
}
