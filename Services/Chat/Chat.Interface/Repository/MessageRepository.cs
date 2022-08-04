using Chat.Application.Contracts.Persisence;
using Chat.Domain.Entities.MessageE;
using Chat.Infrastructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace Chat.Infrastructure.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatContext _chatContext;

        public MessageRepository(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        public async Task AddNewFiles(List<File> files)
        {
            await _chatContext.Files.InsertManyAsync(files);
        }

        public async Task<Message> AddNewMessage(Message message)
        {
            await _chatContext.Messages.InsertOneAsync(message);
            return message;
        }
        public async Task<bool> JoinInGroup(string groupId,long UserId)
        {
        var res=  await  (await _chatContext.Joins.FindAsync(p => p.Group_Id == groupId && p.User_Id == UserId)).FirstOrDefaultAsync();
            if (res == null)
                return false;
            return true;
        }
    }
}
