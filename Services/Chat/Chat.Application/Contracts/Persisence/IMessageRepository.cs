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
        Task AddNewFiles(List<File> files);
        Task<bool> ChckMessageForUser(long userId,string messageid);
        Task<Message> GetMessage(string messageid);
        Task<bool> RemoveMessage(string messageid);
    }
  
}
