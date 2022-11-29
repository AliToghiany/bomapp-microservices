using Common.Services.Utilities;
using Identity.Application.Feature.Contacts.Commands.NewContacs;
using Identity.Application.Feature.Contacts.Commands.NewContact;
using Identity.Application.Feature.Contacts.Queries.GetContacts;
using Identity.Application.Feature.Users.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<ActionResult> NewContacts(CreateNewContactsCommand createNewContactsCommand)
        {
            var userId= UserIdentity.GetID(HttpContext.User);
            createNewContactsCommand.UserId = userId;
            await _mediator.Send(createNewContactsCommand);
            return Ok();
                
           
        }
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        
        public async Task<ActionResult> NewContact(CreateNewContactCommand createNewContactCommand)
        {
            if(string.IsNullOrEmpty(createNewContactCommand.FirstName)|| string.IsNullOrEmpty(createNewContactCommand.Phone)) 
            {
                return BadRequest();
            }
            createNewContactCommand.setId( UserIdentity.GetID(HttpContext.User));
             await _mediator.Send(createNewContactCommand);
           
            return Ok(await _mediator.Send(createNewContactCommand));


        }
        [Authorize]
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<GetContactsResponse>> GetContacts()
        {
            var userId = UserIdentity.GetID(HttpContext.User);
            var contactResponse= await _mediator.Send(new GetContactsQuery(userId));
            return Ok(contactResponse);


        }
        

    }
}
