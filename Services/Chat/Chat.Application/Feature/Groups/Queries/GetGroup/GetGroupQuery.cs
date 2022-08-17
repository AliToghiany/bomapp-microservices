using AutoMapper;
using Chat.Application.Contracts.Persisence;
using Chat.Domain.Entities.GroupE;
using Common.Services.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Groups.Queries.GetGroup
{
    public record GetGroupQuery(string GroupId) : IRequest<GroupResponse> { }

    public class GetGroupQuesryHandler : IRequestHandler<GetGroupQuery, GroupResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GetGroupQuesryHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GroupResponse> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
         var group=await _groupRepository.GetGroupById(request.GroupId);
            if (group == null)
                throw new NotFoundException("Group", request.GroupId);
         var groupResponse=_mapper.Map<GroupResponse>(group);
            foreach (var item in group.GroupProfiles)
            {
                groupResponse.GroupProfileResponses.Add(_mapper.Map<GroupProfileResponse>(item));
            }

            return groupResponse;
        }
      
    }
}
