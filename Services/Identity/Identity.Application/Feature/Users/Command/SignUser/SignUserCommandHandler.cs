using Common.Services.Exceptions;
using Identity.Application.Contracts.Repositories;
using Identity.Domain.User;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Command.SignUser
{
    public class SignUserCommandHandler : IRequestHandler<SignUserCommand, SignUserResponse>
    {
        private readonly ILogger<SignUserCommandHandler> _logger;
       // private readonly IMapper _mapper;
        private readonly IUserRepository _userReposirory;

        public SignUserCommandHandler(ILogger<SignUserCommandHandler> logger/*, IMapper mapper*/, IUserRepository userReposirory)
        {
            _logger = logger;
            //_mapper = mapper;
            _userReposirory = userReposirory;
        }
        public async Task<SignUserResponse> Handle(SignUserCommand request, CancellationToken cancellationToken)
        {
            var confirmRes = await _userReposirory.ConfirmCode(request.ConfirmId, request.Code);
            if (confirmRes == null)
            {
                throw new NotFoundException(nameof(Confirm),request.Code );
            }
            var user =await _userReposirory.FindUserByPhone(confirmRes.Code);
            if(user == null)
            {
                var userId = await _userReposirory.CreateUserByPhone(confirmRes.Phone);
                _logger.LogInformation($"Create User By ID:{userId}");
                return new SignUserResponse
                {
                    UserId = userId,
                    IsNew = true
                };
            }
            return new SignUserResponse
            {
                UserId = user.Id,
                IsNew = false
            };
        }
        
    }
}
