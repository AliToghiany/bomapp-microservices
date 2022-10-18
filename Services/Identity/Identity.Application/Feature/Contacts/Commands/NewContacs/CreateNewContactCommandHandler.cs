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
    public class CreateNewContactCommandHandler : IRequestHandler<CreateNewContactCommand,List< ContactResponse>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        public CreateNewContactCommandHandler(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }

        public async Task<List<ContactResponse>> Handle(CreateNewContactCommand request, CancellationToken cancellationToken)
        {
           var contacts=await _contactRepository.GetContacts(request.UserId);
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
          var res= await _contactRepository.NewRangeContacts(contactsList);
            return contactsList.Select(p=>new ContactResponse
            {
                Contact=p.WithUser,
                Name=p.ContactName
            }).ToList();
        }
    }
}
