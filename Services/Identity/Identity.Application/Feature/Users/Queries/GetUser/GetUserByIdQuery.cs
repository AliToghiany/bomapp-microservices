using AutoMapper;
using Common.Services.Exceptions;
using Identity.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Queries.GetUser
{
    public record GetUserByIdQuery(long MyUserId,long ForUserId) : IRequest<ResponseUser> { }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResponseUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper, IContactRepository contactRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<ResponseUser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user =await _userRepository.FindUserById(request.ForUserId);
            if (user == null)
                throw new NotFoundException("User", request.ForUserId);
            var contact = await _contactRepository.GetContact(request.MyUserId, user.Id);
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
            return responseUser;

        }
    }


}
