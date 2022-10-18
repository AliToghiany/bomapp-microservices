using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Identity.Application.Feature.Users.Command.ConfirmUser;
using Identity.Application.Feature.Users.Command.SignUser;
using Common.Services.Exceptions;
using Identity.Api.Utilities;

namespace Identity.Api.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;

        public AuthController(IMediator mediator, ITokenService tokenService)
        {
            _mediator = mediator;
            _tokenService = tokenService;
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ResponseSendCode>> SendCode([FromBody] ConfirmUserCommand confirmUserCommand)
        {
            confirmUserCommand.IP = "226.125.3.1";
            var res = await _mediator.Send(confirmUserCommand);
            return Ok(new ResponseSendCode { Code=res});
            

        }
        public class ResponseSendCode
        {
            public Guid Code { get; set; }
        }
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task< ActionResult<SignUserResponse>> ConfirmCode([FromBody] SignUserCommand signUserCommand)
        {
            var res = await _mediator.Send(signUserCommand);
            res.Token = _tokenService.BuildToken(res.UserId);
            return Ok(res);



        }
      
        
    }
}
