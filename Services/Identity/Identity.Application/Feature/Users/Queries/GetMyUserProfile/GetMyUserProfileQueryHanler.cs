using AutoMapper;
using Common.Services.Exceptions;
using Identity.Application.Contracts.Repositories;
using Identity.Application.Feature.Users.Queries.GetUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Queries.GetMyUserProfile
{
    public record GetMyUserProfileQuery(long UserId):IRequest<GetMyUserProfileResponse>;
    public class GetMyUserProfileQueryHanler : IRequestHandler<GetMyUserProfileQuery, GetMyUserProfileResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetMyUserProfileQueryHanler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetMyUserProfileResponse> Handle(GetMyUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user=await _userRepository.FindUserById(request.UserId);
            var responseUser = _mapper.Map<GetMyUserProfileResponse>(user);
            responseUser.ImagesProfileResponses = user!.UserImages.Select(p => new ImagesProfileResponse
            {
                Name = p.Name,
                Path = p.Path
            }).ToList();
            return responseUser;


        }
    }

    public class GetMyUserProfileResponse: ResponseUser
    {
   
        public string Description { get; set; }

    }






}
