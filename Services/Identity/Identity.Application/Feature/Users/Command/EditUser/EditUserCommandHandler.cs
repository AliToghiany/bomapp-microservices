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
    internal class EditUserCommandHandler : IRequestHandler<EditUserCommand, ResultResponse>
    {
       // private readonly ILogger _logger;
        // private readonly IMapper _mapper;
        private readonly IUserReposirory _userReposirory;

        public EditUserCommandHandler(/*ILogger logger*//*, IMapper mapper*/ IUserReposirory userReposirory)
        {
          //  _logger = logger;
            //_mapper = mapper;
            _userReposirory = userReposirory;
        }
        public async Task<ResultResponse> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
           var user = await _userReposirory.FindUserById(request.Id);
            if (user == null)
                throw new NotFoundException(nameof(User),request.Id);
            if(request.UserName!=null)
                if(await _userReposirory.IsFreeUserName(request.UserName))
                 user.UserName = request.UserName;
            if(request.FirstName!=null&& request.FirstName != null)
                user.FirstName = request.FirstName;
            if(request.Description!=null)
                user.Description = request.Description;
            await _userReposirory.EditUser(user);
            return new ResultResponse
            {
                IsSucsse = true,
                Message = $"user has sucssesfuled edit with ID:{user.Id}"
            };

        }
    }
}
