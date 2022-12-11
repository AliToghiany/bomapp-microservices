using Identity.Application.Contracts.Repositories;
using Identity.Application.Feature.Users.Queries.GetUser;
using Identity.Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public GetUsersQueryHandler(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<GetUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
           var users = _userRepository.GetUserBySearchKey(request.SearchKey).ToList();
           users = users.Take(request.Take).ToList();
           users.AddRange(await _userRepository.GetUsersByUserName(request.UserName));
//delete again inserts
            return new GetUsersResponse
            {
                Users = await _mediator.Send(new GetUsersById.GetUsersByUsersQuery(users, request.UserId))
            };
        }
    }
}
