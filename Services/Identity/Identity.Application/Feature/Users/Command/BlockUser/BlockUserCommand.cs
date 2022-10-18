using Common.Services.Exceptions;
using Identity.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Command.BlockUser
{
    public record BlockUserCommand(long UserId,long BlockedUser):IRequest<bool>;
    public class BlockUserCommandHandler : IRequestHandler<BlockUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public BlockUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
         
        public async Task<bool> Handle(BlockUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindUserById(request.BlockedUser);
            if (user==null)
            {
                throw new NotFoundException("User", request.BlockedUser);
            }
            //ی سری عملیات قبل بلاک
            return await _userRepository.BlockUser(request.UserId, request.BlockedUser);
        }
    }
}
