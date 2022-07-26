using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Identity.Application.Feature.Users.Command.ConfirmUser;
using Identity.Application.Feature.Users.Command.SignUser;

namespace Identity.Api.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task< ActionResult<SignUserResponse>> ConfirmCode([FromBody]Guid id, [FromBody] string code)
        {
            var res = await _mediator.Send(new SignUserCommand() { Code=code,ConfirmId=id});
            return Ok(res);
            

        }
    }
}
