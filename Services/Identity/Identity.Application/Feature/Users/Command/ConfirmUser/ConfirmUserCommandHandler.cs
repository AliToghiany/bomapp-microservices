using AutoMapper;
using Identity.Application.Contracts.Repositories;
using Identity.Domain.User;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Command.ConfirmUser
{
    internal class ConfirmUserCommandHandler : IRequestHandler<ConfirmUserCommand, Guid>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUserReposirory _userReposirory;

        public ConfirmUserCommandHandler(ILogger logger, IMapper mapper, IUserReposirory userReposirory)
        {
            _logger = logger;
            _mapper = mapper;
            _userReposirory = userReposirory;
        }

        public async Task<Guid> Handle(ConfirmUserCommand request, CancellationToken cancellationToken)
        {
            var confirmUser = _mapper.Map<Confirm>(request);
            confirmUser.Code = getRandom();
            var res = await _userReposirory.CreateNewConfirm(confirmUser);
            _logger.LogInformation($"Send Sms To IP:{res.IP} With Id{res.Id}");
            return res.Id;



        }
        string getRandom()
        {
            Random random = new Random();
            return random.Next(1, 9).ToString() + random.Next(1, 9).ToString() + random.Next(1, 9).ToString() + random.Next(1, 9).ToString() + random.Next(1, 9).ToString() + random.Next(1, 9).ToString();
        }
    }
}
