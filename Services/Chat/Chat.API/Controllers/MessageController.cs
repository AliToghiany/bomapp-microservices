
using Chat.API.Hubs;
using Chat.API.Respositories.Interface;
using Chat.Application.Feature.Groups.Queries.GetGroupMember;
using Chat.Application.Feature.Messages.Commands;
using Chat.Application.Feature.Messages.Commands.CreateMessage;

using Chat.Application.Feature.Messages.Queries.GetMessage;
using Chat.Domain.Entities.MessageE;
using Common.Services.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net;

namespace Chat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubRepository _hubRepository;
        private readonly IHubContext<ReciveHub>  _reciveHub;
        public MessageController(IMediator mediator, IHubRepository hubRepository, IHubContext<ReciveHub> reciveHub)
        {
            _mediator = mediator;
            _hubRepository = hubRepository;
            _reciveHub = reciveHub;

        }
        [HttpGet]
        public async Task<ActionResult> ddd()
        {
            await _reciveHub.Clients.All.SendAsync("ReciveMessage", "data");
            return Ok();
        }

        [ProducesResponseType(typeof(ResponseMessage),(int)HttpStatusCode.OK) ]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Authorize]
       
        [HttpPost]
        public async Task<ActionResult> NewMessage(CreateNewMessageCommand createNewMessageCommand)
        {
           try
            {
                var res = await _mediator.Send(createNewMessageCommand);
                var message = await _mediator.Send<ResponseMessage>(new GetMessageQuery(res));
                var messagejson = JsonConvert.SerializeObject(message);
                if (createNewMessageCommand.ToUser_Id != null || createNewMessageCommand.ToUser_Id != 0)
                {
                 var cid=  await _hubRepository.GetConnectionOrAddQueue(new List<long> { createNewMessageCommand.ToUser_Id.Value },messagejson,"NewMessage");
                    if (cid.Count!=0)
                    {
                        foreach (var item in cid)
                        {
                           await _reciveHub.Clients.Client(item).SendAsync("ReciveMessage", messagejson);
                        }
                       
                    }
                }
                else if (createNewMessageCommand.Group_Id != null)
                {
                    var users = await _mediator.Send<List<long>>(new GetGroupMemberQuery(createNewMessageCommand.Group_Id));

                 var cid=  await _hubRepository.GetConnectionOrAddQueue(users, messagejson,"NewMessage");
                    if (cid.Count != 0)
                    {
                        foreach (var item in cid)
                        {
                          await  _reciveHub.Clients.Client(item).SendAsync("ReciveMessage", messagejson);
                        }

                    }
                }
                    return Ok();
            }
          
            
            catch (Exception ex)
            {

                if (ex is NotFoundException)
                {
                 return NotFound(ex.Message);
                }
                if (ex is UnauthorizedAccessException)
                {
                    return Unauthorized(ex.Message);
                }
                return BadRequest();
            }
          


        }
        
    }
}
