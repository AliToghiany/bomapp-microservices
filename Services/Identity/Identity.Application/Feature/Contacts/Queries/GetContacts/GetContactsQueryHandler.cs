using Identity.Application.Contracts.Repositories;
using Identity.Application.Feature.Users.Queries.GetUser;
using Identity.Application.Feature.Users.Queries.GetUsersById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Contacts.Queries.GetContacts
{
    public record GetContactsQuery(long UserId):IRequest<GetContactsResponse>;
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, GetContactsResponse>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMediator _mediator;

        public GetContactsQueryHandler(IContactRepository contactRepository, IMediator mediator)
        {
            _contactRepository = contactRepository;
            _mediator = mediator;
        }

        public async Task<GetContactsResponse> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = _contactRepository.GetContacts(request.UserId);
            return new GetContactsResponse
            {
                Contact= await _mediator.Send(new GetUsersByUsersQuery(contacts.Select(p => p.WithUser), request.UserId))
        };
                
            

        }
        
    }
    public class GetContactsResponse
    {
        public List<ResponseUser> Contact { get; set; }
    }
}
