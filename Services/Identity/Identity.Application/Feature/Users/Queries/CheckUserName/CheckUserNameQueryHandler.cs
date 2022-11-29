using Identity.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Queries.CheckUserName
{
    public record CheckUserNameQuery(long UserId, string Username) : IRequest<CheckUserNameResponse>;
    public class CheckUserNameQueryHandler : IRequestHandler<CheckUserNameQuery, CheckUserNameResponse>
    {
        private readonly IUserRepository _userRepository;

        public CheckUserNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CheckUserNameResponse> Handle(CheckUserNameQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Username))
            {
                return new CheckUserNameResponse
                {
                    Checked = false,
                    Message = "Username is empty"
                };
            }
            if (request.Username.Length < 4)
            {
                return new CheckUserNameResponse
                {
                    Checked = false,
                    Message = "Username not less than 4 characters"
                };
            }
                if (!ValidateBomAppUsername(request.Username))
                {
                    return new CheckUserNameResponse
                    {
                        Checked = false,
                        Message = "Do not enter illegal characters"
                    };
                }

                var isFree = await _userRepository.IsFreeUserName(request.Username, request.UserId);
                if (!isFree)
                {
                    return new CheckUserNameResponse
                    {
                        Checked = false,
                        Message = "this Username is taken"
                    };

                }
                return new CheckUserNameResponse
                {
                    Checked = true,
                    Message = "Username is correct and free"

                };

            
            
        }
        bool ValidateBomAppUsername(string username)
        => Regex.IsMatch(username,
            @"^(?=.{4,32}$)(?!.*__)(?!^(bomapp|admin|support))[a-z][a-z0-9_]*[a-z0-9]$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

    } 
    public class CheckUserNameResponse
        {
            public bool Checked { get; set; }
            public string Message { get; set; }
        }
}
