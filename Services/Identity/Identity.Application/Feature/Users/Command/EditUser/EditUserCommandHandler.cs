using Common.Services.DTO;
using Common.Services.Exceptions;
using Identity.Application.Contracts.Repositories;
using Identity.Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Command.EditUser
{
    internal class EditUserCommandHandler : IRequestHandler<EditUserCommand>
    {
       // private readonly ILogger _logger;
        // private readonly IMapper _mapper;
        private readonly IUserRepository _userReposirory;

        public EditUserCommandHandler(/*ILogger logger*//*, IMapper mapper*/ IUserRepository userReposirory)
        {
          //  _logger = logger;
            //_mapper = mapper;
            _userReposirory = userReposirory;
        }
        public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
           var user = await _userReposirory.FindUserById(request.Id);
            if (user == null)
                throw new NotFoundException(nameof(User),request.Id);
            user.UserName = request.UserName;
            user.FirstName= request.FirstName; 
               
            if (request.LastName != null)
                user.FirstName = request.FirstName;
          
            await _userReposirory.EditUser(user);
            return Unit.Value;
          

        }
    }
}
