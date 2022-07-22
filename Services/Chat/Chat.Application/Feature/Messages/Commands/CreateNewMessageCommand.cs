using Chat.Domain.Entities.MessageE;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Commands
{
    public class CreateNewMessageCommand:IRequest<long>
    {
        public long User_Id { get; set; }
        public long Group_Id { get; set; }
        public long ToUser_Id { get; set; }
        public string Reply_To_MessageId { get; set; }
        public string Text { get; set; }
        public long Sticker_Id { get; set; }
        public long Gif_Id { get; set; }

        public List<File> Files { get; set; }

    }
    public class File
    {
      public  IFormFile Upload { get; set; }
      
      
    }
}
