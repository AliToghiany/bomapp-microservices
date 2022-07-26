using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Command.SignUser
{
    public class SignUserCommand:IRequest<SignUserResponse>
    {
        public Guid ConfirmId { get; set; }
        public string Code { get; set; }
    }

}
