using Chat.Domain.Entities.MessageE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contracts.Persisence
{
    public interface IMessageRepository
    {
        Task<Message> AddNewMessage(Message message);
       
    }
}
