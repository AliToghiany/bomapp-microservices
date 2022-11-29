using Chat.Application.Contracts.EndPoint;
using Chat.Application.Feature.Groups.Commands.NewGroup;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Commands.CreateMessage
{
    public record NewMessageNotification(long MessageId) : INotification;
    public class NewMessageNotificationHandler : INotificationHandler<NewMessageNotification>
    {
        private readonly IMediator _mediator;
        private readonly IReciveHub _reciveHub;

        public NewMessageNotificationHandler(IMediator mediator, IReciveHub reciveHub)
        {
            _mediator = mediator;
            _reciveHub = reciveHub;
        }

        public async Task Handle(NewMessageNotification notification, CancellationToken cancellationToken)
        {
            var message =await _mediator.Send(new GetMessageQuery(notification.MessageId));
            await _reciveHub.SendMessage(message);


        }
    }
}
