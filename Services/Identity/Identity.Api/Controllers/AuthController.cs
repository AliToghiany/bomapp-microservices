using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Identity.Application.Feature.Users.Command.ConfirmUser;

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
        public async Task<ActionResult<Guid>> SendCode(string phone,string ip)
        {
          //  var res = await _mediator.Send(new ConfirmUserCommand {Phone=phone,IP=ip });
            return Ok();
            

        }
    }
}
