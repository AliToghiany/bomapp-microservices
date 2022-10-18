using Chat.Application.Contracts.Persisence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Groups.Queries.GetGroupMember
{
    public record GetGroupMemberQuery(long GroupId) : IRequest<List<long>> { }
    public class GetGroupMemberQueryHandler : IRequestHandler<GetGroupMemberQuery, List<long>>
    {
        private readonly IGroupRepository _groupRepository;

        public GetGroupMemberQueryHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<List<long>> Handle(GetGroupMemberQuery request, CancellationToken cancellationToken)
        {
            var users = await _groupRepository.GetMemberOfGroup(request.GroupId);
            return users;
        }
    }
    
    
}
