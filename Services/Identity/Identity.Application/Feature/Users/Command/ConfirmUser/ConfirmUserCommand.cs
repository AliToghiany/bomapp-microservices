using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Identity.Application.Feature.Users.Command.ConfirmUser
{

    internal class ConfirmUserCommand : IRequest<Guid>
    {
        public string IP { get; set; }
        public string Phone { get; set; }

    }
}

