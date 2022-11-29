using Chat.Domain.Entities.MessageE;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Commands.CreateMessage
{
    public class CreateNewMessageCommand:IRequest<long>
    {
        public long User_Id { get; set; }
        public long? GroupId { get; set; }
        public long? ToUser_Id { get; set; }
        public long? ReplyToMessageId { get; set; }
        public string Text { get; set; }
        public long? StickerId { get; set; }
        public long? GifId { get; set; }

        


    }
   
}
