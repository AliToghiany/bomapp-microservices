using Chat.Application.Contracts.Persisence;
using Chat.Application.Feature.Groups.Queries.GetGroup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Groups.Commands.EditGroup
{
    public class EditGroupCommandHandler : IRequestHandler<EditGroupCommand, GroupResponse>
    {
        private readonly IGroupRepository _groupRepository;

        public EditGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public Task<GroupResponse> Handle(EditGroupCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GroupResponse { });
        }
    }
}
