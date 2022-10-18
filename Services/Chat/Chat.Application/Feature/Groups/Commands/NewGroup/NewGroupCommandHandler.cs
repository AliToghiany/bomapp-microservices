using AutoMapper;
using Chat.Application.Contracts.Persisence;
using Chat.Application.Feature.Groups.Queries.GetGroup;
using Chat.Domain.Entities.GroupE;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Groups.Commands.NewGroup
{
   
    public class NewGroupCommandHandler : IRequestHandler<NewGroupCommand, GroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly IMediator _mediator;

        public NewGroupCommandHandler(IMapper mapper, IGroupRepository groupRepository, IMediator mediator) 
        {
            _mediator = mediator;
            _groupRepository = groupRepository;
            _mediator=mediator;
        }

       

        public async Task<GroupResponse> Handle(NewGroupCommand request, CancellationToken cancellationToken)
        {
            var group = _mapper.Map<Group>(request);
            if (await _groupRepository.CheckGroupName(group.GroupName))
            {
                group.GroupName = null;
            }
            var res=await _groupRepository.NewGroup(group);
            var groupProfile = new GroupProfile
            {
                GroupId = res.Id,
                Name = Guid.NewGuid().ToString(),
                Path = request.ImageGroupUrl,

            };
            await _groupRepository.CreateImageGroup(groupProfile);
            res.GroupProfiles.Add(groupProfile);
            await _mediator.Publish(new NewGroupNotification { UserId = request.Owner, GroupId = res.Id, SubescribesId = request.DefualtUser });
            return _mapper.Map<GroupResponse>(res);
        }
    }
}
