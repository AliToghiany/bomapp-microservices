using Chat.Application.Contracts.Persisence;
using Chat.Application.Feature.Groups.Queries.GetGroup;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using Chat.Application.Feature.Messages.Queries.GetMessagesByData;
using Chat.Domain.Entities.MessageE;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Queries.LoadingMessage
{
    public class LoadMessageQueryHandler : IRequestHandler<LoadMessageQuery>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMediator _mediator;

        public LoadMessageQueryHandler(IMessageRepository messageRepository, IMediator mediator)
        {
            _messageRepository = messageRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(LoadMessageQuery request, CancellationToken cancellationToken)
        {
            if (request.LastMessageId != null)
            {
                var message = 
                    await _mediator.Send
                    (new GetMessageQuery(request.LastMessageId.Value,request.UserId));
                var messages =await _messageRepository.GetMessageLastMessage(message.Id);
               var res=await _mediator.Send(new GetMessagesByDataQuery(messages.Take(100).ToList()));
                //sub
                return Unit.Value;

            }
            if (request.FirstMessageId != null)
            {
                var message =
                    await _mediator.Send
                    (new GetMessageQuery(request.LastMessageId.Value, request.UserId));
                var messages = await _messageRepository.GetMessageLastMessage(message.Id);
                var res = await _mediator.Send(new GetMessagesByDataQuery(messages.Take(100).ToList()));
                //sub
                return Unit.Value;

            }
            if(request.GroupId != null)
            {
                var group = await _mediator.Send(new GetGroupQuery(request.GroupId.Value));
                var messages = await _messageRepository.GetMessageFromGroup(group.Id);
                var res = await _mediator.Send(new GetMessagesByDataQuery(messages.Take(100).ToList()));
                //sub
                return Unit.Value;

            }
            if (request.PrivateUserId != null)
            {
               
                var messages = await _messageRepository.GetMessageFromPrivate(request.UserId,request.PrivateUserId.Value);
                var res = await _mediator.Send(new GetMessagesByDataQuery(messages.Take(100).ToList()));
                //sub
                return Unit.Value;

            }
            return Unit.Value;

        }
    }
}
