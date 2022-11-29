using Common.Services.Exceptions;
using Identity.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Command.EditAbout
{
    public record EditAboutCommand(string Description,long UserId):IRequest;

    public class EditAboutCommandHandler : IRequestHandler<EditAboutCommand>
    { 
        private readonly IUserRepository _userRepository;

        public EditAboutCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(EditAboutCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Description))
            {
                var user = await _userRepository.FindUserById(request.UserId);
                if (user == null)
                    throw new NotFoundException("User", request.UserId);
                user.Description = request.Description;
                await _userRepository.EditUser(user);

            }
            return Unit.Value;
        }
    }
}
