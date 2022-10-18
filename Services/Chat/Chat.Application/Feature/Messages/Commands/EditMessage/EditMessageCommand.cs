using Chat.Application.Feature.Messages.Queries.GetMessage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Commands.EditMessage
{
    public class EditMessageCommand:IRequest<ResponseMessage>
    {
        public long UserId { get; set; }
        public long MessageId { get; set; }
        public List<string> Files { get; set; }
        public string Text { get; set; }
    }
}
