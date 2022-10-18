using AutoMapper;
using Chat.Application.Feature.Groups.Commands.NewGroup;
using Chat.Application.Feature.Groups.Queries.GetGroup;
using Chat.Application.Feature.Messages.Commands;
using Chat.Application.Feature.Messages.Commands.CreateMessage;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using Chat.Domain.Entities.GroupE;
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
            CreateMap<Group, GroupResponse>().ReverseMap();
            CreateMap<GroupProfile, GroupProfileResponse>().ReverseMap();
            CreateMap<Message, ResponseMessage>().ReverseMap();
            CreateMap<File, FileDto>().ReverseMap();
            CreateMap<Group, NewGroupCommand>().ReverseMap();
        }
    }
}
