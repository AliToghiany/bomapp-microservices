using Chat.Application.Feature.Messages.Queries.GetMessage;
using Chat.Domain.Entities.MessageE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contracts.EndPoint
{
    public interface IReciveHub
    {
        
        Task SendMessageNewGroup(long groupId, List<long> subescribesId,long cretedBy);
        Task SendMessage(ResponseMessage message);

    }
}
