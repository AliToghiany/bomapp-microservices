
using Chat.API.Hubs;
using Chat.API.Respositories.Interface;
using Chat.Application.Feature.Groups.Queries.GetGroupMember;
using Chat.Application.Feature.Messages.Commands;
using Chat.Application.Feature.Messages.Commands.CreateMessage;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using Chat.Application.Feature.Messages.Queries.LoadingMessage;
using Chat.Domain.Entities.MessageE;
using Common.Services.Exceptions;
using Common.Services.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net;

namespace Chat.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubRepository _hubRepository;
   
        public MessageController(IMediator mediator, IHubRepository hubRepository)
        {
            _mediator = mediator;
            _hubRepository = hubRepository;


        }
       

        [ProducesResponseType(typeof(ResponseMessage),(int)HttpStatusCode.OK) ]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Authorize]
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> NewMessage(CreateNewMessageCommand createNewMessageCommand)
        {
          createNewMessageCommand.User_Id= UserIdentity.GetID(HttpContext.User);
            var res = await _mediator.Send(createNewMessageCommand);
                var message = await _mediator.Send<ResponseMessage>(new GetMessageQuery(res, createNewMessageCommand.User_Id));
                return Ok(message);
            
        }
        
      

        
        
    }
}
