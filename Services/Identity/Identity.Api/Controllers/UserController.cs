using Common.Services.Utilities;
using Identity.Api.GrpcSerivces;
using Identity.Application.Feature.Users.Command.BlockUser;
using Identity.Application.Feature.Users.Command.EditAbout;
using Identity.Application.Feature.Users.Command.EditUser;
using Identity.Application.Feature.Users.Command.SignUser;
using Identity.Application.Feature.Users.Queries.CheckUserName;
using Identity.Application.Feature.Users.Queries.GetMyUserProfile;
using Identity.Application.Feature.Users.Queries.GetUser;
using Identity.Application.Feature.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly InviteLinkService _inviteLinkService;

        public UserController(IMediator mediator, InviteLinkService inviteLinkService)
        {
            _mediator = mediator;
            _inviteLinkService = inviteLinkService;
        }

        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] EditUserCommand editUserCommand)
        {
            editUserCommand.Id = UserIdentity.GetID(HttpContext.User);
            var username = await _inviteLinkService.CheckUserName(editUserCommand.UserName);
           
            var res = await _mediator.Send(new CheckUserNameQuery(editUserCommand.Id, editUserCommand.UserName));
            if (!string.IsNullOrEmpty( username.InviteLinkName) )
            {
                if (username.Serivce != "Identity")
                {
                    return BadRequest("This UserName is taken");
                }

            }
            else
            {
                if (res.Checked)
                {
                  var nusername= await _inviteLinkService.NewUserName(editUserCommand.UserName);
                    if (nusername == null)
                    {
                        return BadRequest("UserName Service Stop"); ;
                    }
                }
            }
            if (!res.Checked)
            {
                return BadRequest(res.Message);
            }
            if (string.IsNullOrEmpty(editUserCommand.FirstName))
            {
                return BadRequest("First Name is Empty");
            }
            await _mediator.Send(editUserCommand);
            return Ok();
        }
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> UpdateAboutUser([FromBody] string Description)
        {
           
            await _mediator.Send(new EditAboutCommand(Description, UserIdentity.GetID(HttpContext.User)));
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
            var res = await _mediator.Send(new GetUserByIdQuery( UserIdentity.GetID(HttpContext.User),userId));
            return Ok(res);

        }
        [Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<bool>> BlockUser([FromBody]BlockUserCommand blockUserCommand)
        { 
            //blockUserCommand.UserId=
          return await _mediator.Send(blockUserCommand);
        }

        [Authorize]
        [ProducesResponseType(typeof(GetUsersResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<GetUsersResponse>> GetUsersBySearch(string shearchKey)
        {
            var userSearch=await _inviteLinkService.SearchUserName(shearchKey);
            var res =await _mediator.Send
                (new GetUsersQuery
                (shearchKey,userSearch.Listresponse.Select(p=>p.InviteLinkName).ToList(),3, UserIdentity.GetID(HttpContext.User)));
          
            return Ok(res);
        }
        [Authorize]
        [ProducesResponseType(typeof(GetMyUserProfileResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<GetMyUserProfileResponse>> GetMyProfile()
        {
            return
                await _mediator.Send(new GetMyUserProfileQuery(UserIdentity.GetID(HttpContext.User)));
        }
        [Authorize]
        [ProducesResponseType(typeof(CheckUserNameResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [Route("[action]/{userName}")]
        [HttpGet]
        public async Task<ActionResult<CheckUserNameResponse>> CheckUserName(string userName)
        {
            return
                Ok(await _mediator.Send(new CheckUserNameQuery(UserIdentity.GetID(HttpContext.User),userName)));
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
