using Common.Services.Exceptions;
using Identity.Application.Contracts.Repositories;
using Identity.Application.Feature.Users.Queries.GetUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Contacts.Commands.NewContact
{
    public class CreateNewContactCommand : IRequest<ResponseUser>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        internal long Id { get; set; }
        public void setId(long id)
        {
            Id = id;
        }

    }
    public class CreateNewContactCommandHandler : IRequestHandler<CreateNewContactCommand, ResponseUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMediator _mediator;

        public CreateNewContactCommandHandler(IUserRepository userRepository, IContactRepository contactRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _contactRepository = contactRepository;
            _mediator = mediator;
        }

        public async Task<ResponseUser> Handle(CreateNewContactCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindUserByPhone(request.Phone);
            if (user == null)
            {
                throw new NotFoundException("User", request.Phone);
            }
            if (user.Id==request.Id)
            {
                throw new BadRequestException("Phone");
            }
            await _contactRepository.NewRangeContacts(new List<Domain.User.Contact>
            {
                new Domain.User.Contact()
                {
                    ContactName = request.FirstName,
                    LastName = request.LastName,
                    ForUserId=request.Id,
                    WithUserId=user.Id
                }
            });
            var res = await _mediator.Send(new GetUserByIdQuery(request.Id, user.Id));
            return res;


        }
    }
}
