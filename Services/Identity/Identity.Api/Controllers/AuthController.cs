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
        public async Task< ActionResult<Guid>> SendCode([FromBody]string phone)
        {
            var res = await _mediator.Send(new ConfirmUserCommand {Phone=phone,IP="192.168.42.27" });
            return Ok(res);
            

        }
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task< ActionResult<SignUserResponse>> ConfirmCode([FromBody] RequestConfirmCode requestConfirmCode)
        {
            try
            {
                var res = await _mediator.Send(new SignUserCommand() { Code = requestConfirmCode.Code, ConfirmId = requestConfirmCode.Id });
                res.Token =  _tokenService.BuildToken(res.UserId);
                return Ok(res);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public class RequestConfirmCode
        {
            public Guid Id { get; set; }
            public string Code { get; set; }
        }
    }
}
