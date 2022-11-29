using Identity.Application.Contracts.Repositories;
using Identity.Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Contacts.Commands.NewContacs
{
    public class CreateNewContactsCommandHandler : IRequestHandler<CreateNewContactsCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        public CreateNewContactsCommandHandler(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateNewContactsCommand request, CancellationToken cancellationToken)
        {
           var contacts=_contactRepository.GetContacts(request.UserId);
           List<Contact>contactsList=new List<Contact>();
           foreach (var contact in request.NewContactRequests)
           {
                var user=await _userRepository.FindUserByPhone(contact.Phone);
                if (user != null)
                    if (contacts.Any(p => p.WithUserId == user.Id))
                        continue;
                    else
                        contactsList.Add(new Contact { ContactName = contact.Name, ForUserId = request.UserId, WithUser = user, WithUserId = user.Id });
                else
                    continue;
           }
          await _contactRepository.NewRangeContacts(contactsList);
            return Unit.Value;
        }
    }
}
