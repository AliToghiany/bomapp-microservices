using AutoMapper;
using Chat.Application.Contracts.EndPoint;

using Chat.Application.Contracts.Persisence;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Groups.Commands.NewGroup
{
    public class NewGroupNotification:INotification
    {
        public long GroupId { get; set; }
        public long UserId { get; set; }
        public List<long> SubescribesId { get; set; }
    }
    public class NewGroupNotificationHandler : INotificationHandler<NewGroupNotification>
    {
        private readonly IReciveHub _reciveHub;

        public NewGroupNotificationHandler(IReciveHub reciveHub)
        {
            _reciveHub = reciveHub;
        }

        public async Task Handle(NewGroupNotification notification, CancellationToken cancellationToken)
        {
            await _reciveHub.SendMessageNewGroup(notification.GroupId,notification.SubescribesId,notification.UserId);
        }
    }
 
   
}
