using Chat.Application.Feature.Groups.Queries.GetGroup;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.Application.Feature.Groups.Commands.NewGroup
{
    public class NewGroupCommand:IRequest<GroupResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public List<long> DefualtUser { get; set; }
        public string ImageGroupUrl { get; set; }
        public long Owner { get; set; }
    }
}
