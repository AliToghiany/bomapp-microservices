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
        
        Task<Message> GetMessage(long messageid);
        Task<bool> UpdateMessage(Message message);

        Task<List<long>> GetAllPrivateRoom(long userId);
        Task<List<Message>> GetGroupMessage(long userId);
        Task<List<Message>> GetPrivateRoomMessage(long userId);
        Task<List<Message>> GetMessageLastMessage(long lastMessageId);
        Task<List<Message>> GetMessageFirstMessage(long lastMessageId);
        Task<List<Message>> GetMessageFromGroup(long id);
        Task<List<Message>> GetMessageFromPrivate(long userId,long toUserId);
    }
  
}
