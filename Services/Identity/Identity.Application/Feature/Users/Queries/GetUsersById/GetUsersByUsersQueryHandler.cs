using AutoMapper;
using Common.Services.Exceptions;
using Identity.Application.Contracts.Repositories;
using Identity.Application.Feature.Users.Queries.GetUser;
using Identity.Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Queries.GetUsersById
{
    public record GetUsersByUsersQuery(IEnumerable<User> Users,long UserId):IRequest<List<ResponseUser>>;
    public class GetUsersByUsersQueryHandler : IRequestHandler<GetUsersByUsersQuery, List<ResponseUser>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public GetUsersByUsersQueryHandler(IUserRepository userRepository, IMapper mapper, IContactRepository contactRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<List<ResponseUser>> Handle(GetUsersByUsersQuery request, CancellationToken cancellationToken)
        {

            List < ResponseUser > response=new List<ResponseUser> ();

            foreach (var user in request.Users)
            {
                if (user.Id == request.UserId)
                {
                    var responseUser = _mapper.Map<ResponseUser>(user);
                    responseUser.ImagesProfileResponses = user.UserImages.Select(p => new ImagesProfileResponse
                    {
                        Name = p.Name,
                        Path = p.Path,


                    }).ToList();
                    response.Add(responseUser);
                }
                else
                {
                    var contact = await _contactRepository.GetContact(request.UserId, user.Id);
                    if (!user.ShowPhoneNumber)
                        if (contact == null)
                            user.PhoneNumber = "";
                    if (contact != null)
                    {
                        user.FirstName = contact.ContactName;
                        user.LastName = contact.LastName;

                    }


                    var responseUser = _mapper.Map<ResponseUser>(user);

                    responseUser.ImagesProfileResponses = user.UserImages.Select(p => new ImagesProfileResponse
                    {
                        Name = p.Name,
                        Path = p.Path,


                    }).ToList();
                    response.Add(responseUser);
                }
            }
            return response;
        }
    }
}
