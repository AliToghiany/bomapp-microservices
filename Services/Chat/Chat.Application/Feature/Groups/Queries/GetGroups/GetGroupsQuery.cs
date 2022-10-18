using AutoMapper;
using Chat.Application.Common;
using Chat.Application.Contracts.Persisence;
using Chat.Application.Feature.Groups.Queries.GetGroup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Groups.Queries.GetGroups
{
    public record GetGroupsQuery(string SearchKey,int PageSize,int Page) : IRequest<List<GroupResponse>> { }
    public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, List<GroupResponse>>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetGroupsQueryHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public Task<List<GroupResponse>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = _groupRepository.GetGroups();
            int totalRow = 0;
         

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                groups = groups.Where(p => p.Name.Contains(request.SearchKey) || p.GroupName.Contains(request.SearchKey)).AsQueryable();
            }


            var groupsVM = _mapper.Map<List<GroupResponse>>( groups.ToPaged(request.Page, request.PageSize, out totalRow).ToList());



            return Task.FromResult(groupsVM);
        }
    }

}
