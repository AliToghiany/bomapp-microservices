using AutoMapper;
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
    public record GetGroupMemberQuery(long GroupId) : IRequest<List<JoinRsponse>> { }
    public class GetGroupMemberQueryHandler : IRequestHandler<GetGroupMemberQuery, List<JoinRsponse>>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetGroupMemberQueryHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<List<JoinRsponse>> Handle(GetGroupMemberQuery request, CancellationToken cancellationToken)
        {
            var joins = await _groupRepository.GetMemberOfGroup(request.GroupId);
            var j = new List<JoinRsponse>();
            foreach (var join in joins)
                j.Add(_mapper.Map<JoinRsponse>(join));
            return j;
            
        }
    }
    
    
}
