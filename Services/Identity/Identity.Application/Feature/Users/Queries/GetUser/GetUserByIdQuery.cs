﻿using AutoMapper;
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
    public record GetUserByIdQuery(long UserId) : IRequest<ResponseUser> { }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResponseUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseUser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user =await _userRepository.FindUserById(request.UserId);
            if (user == null)
                throw new NotFoundException("User", request.UserId);
            var responseUser = _mapper.Map<ResponseUser>(user);
            responseUser.ImagesProfileResponses=user.UserImages.Select(p=>new ImagesProfileResponse
            {
                Name=p.Name,
                Path=p.Path
            }).ToList();
            return responseUser;
           
        }
    }


}
