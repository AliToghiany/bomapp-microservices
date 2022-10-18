using Common.Services.Utilities;
using Identity.Application.Feature.Users.Command.BlockUser;
using Identity.Application.Feature.Users.Command.EditUser;
using Identity.Application.Feature.Users.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] EditUserCommand editUserCommand)
        {
            editUserCommand.Id = UserIdentity.GetID(HttpContext.User);
            await _mediator.Send(editUserCommand);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseUser), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Authorize]
        [HttpGet("{userId}", Name = "GetUserById")]
        public async Task<ActionResult<ResponseUser>> GetUser(long userId)
        {
            var res = await _mediator.Send(new GetUserByIdQuery(userId));
            return Ok(res);

        }
        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Authorize]
        public async Task<ActionResult<bool>> BlockUser([FromBody]BlockUserCommand blockUserCommand)
        { 
            //blockUserCommand.UserId=
          return await _mediator.Send(blockUserCommand);
        }
        //[HttpGet]
        //[ProducesResponseType(typeof(List<ResponseUser>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[Authorize]
        //[HttpGet("{userId}", Name = "GetUserById")]
        //public async Task<ActionResult<List<ResponseUser>>> GetUsers(string searchKey,int take)
        //{
        //    var res = await _mediator.Send(new GetUserByIdQuery(userId));
        //    return Ok(res);

        //}
    }
}
