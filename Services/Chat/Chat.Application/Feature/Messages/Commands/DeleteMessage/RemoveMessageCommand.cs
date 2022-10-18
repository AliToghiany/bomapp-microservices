using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Commands.DeleteMessage
{
    public class RemoveMessageCommand:IRequest<bool>
    {
        public long UserId { get; set; }
        public long MessageId { get; set; }
    }
}
