using Chat.Application.Contracts.EndPoint;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Queries.LoadingMessage
{
    public record SendMessageNotification(string ConnectionId, List<ResponseMessage> ResponseMessages) :INotification;
    public class SendMessageNotificationHandler : INotificationHandler<SendMessageNotification>
    {
        private readonly IReciveHub _reciveHub;

        public SendMessageNotificationHandler(IReciveHub reciveHub)
        {
            _reciveHub = reciveHub;
        }

        public async Task Handle(SendMessageNotification notification, CancellationToken cancellationToken)
        {
            await _reciveHub.SendMessageForCaller(notification.ConnectionId, notification.ResponseMessages);
        }
    }
}
