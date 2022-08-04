using Chat.Application.Feature.Messages.Commands;
using Chat.Application.Feature.Messages.Commands.CreateMessage;
using Chat.Domain.Entities.MessageE;
using Common.Services.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Chat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(Message), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Message), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Message), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Message), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Message>> NewMessage(CreateNewMessageCommand createNewMessageCommand)
        {
            try
            {
 var res = await _mediator.Send(createNewMessageCommand);
            return CreatedAtRoute("GetMessage", new { id = res }, res);
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
