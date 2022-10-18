using Chat.Application.Feature.Groups.Queries.GetGroup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Groups.Commands.EditGroup
{
    public class EditGroupCommand:IRequest<GroupResponse>
    {
        public long UserId { get; set; }
        public string NewName { get; set; }
        public string NewGroupName { get; set; }
        public string Description { get; set; }

    }
}
