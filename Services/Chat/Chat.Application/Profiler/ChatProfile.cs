using AutoMapper;
using Chat.Application.Feature.Messages.Commands;
using Chat.Domain.Entities.MessageE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Profiler
{
    public class ChatProfile:Profile
    {
        public ChatProfile()
        {
            CreateMap<Message, CreateNewMessageCommand>().ReverseMap();
        }
    }
}
