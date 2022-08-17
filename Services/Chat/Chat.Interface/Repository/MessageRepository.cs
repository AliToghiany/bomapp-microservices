using Chat.Application.Contracts.Persisence;
using Chat.Domain.Entities.MessageE;
using Chat.Infrastructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repository
{
   
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatDbContext _chatContext;

        public MessageRepository(ChatDbContext chatContext)
        {
            _chatContext = chatContext;
        }

        public async Task AddNewFiles(List<File> files)
        {
            await _chatContext.Files.AddRangeAsync(files);
            await _chatContext.SaveChangesAsync();
        }

        public async Task<Message> AddNewMessage(Message message)
        {
            await _chatContext.Messages.AddAsync(message);
            await _chatContext.SaveChangesAsync();
            return message;
        }

        public Task<bool> ChckMessageForUser(long userId, string messageid)
        {
            throw new NotImplementedException();
        }

        public async Task<Message> GetMessage(string messageid)
        {
            return await _chatContext.Messages.Include(p=>p.Files).FirstOrDefaultAsync(p=>p.Id==messageid);

        }
        

        public async Task<bool> JoinInGroup(string groupId,long UserId)
        {
        var res=  await  _chatContext.Joins.FirstOrDefaultAsync(p=>p.GroupId==groupId&&p.UserId==UserId);
            if (res == null)
                return false;
            return true;
        }

        public Task<bool> RemoveMessage(string messageid)
        {
            throw new NotImplementedException();
        }

        public Task<List<long>> GetAllPrivateRoom(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Message>> GetGroupMessage(long userId)
        {
            var gropsid = _chatContext.Joins
              
                .Where(p => p.UserId == userId)
                .Select(p=>p.GroupId);
            List<Message> messages = new List<Message>(); 
            foreach (var group in gropsid)
            {
              messages.Add( await _chatContext.Messages
                    .Include(p => p.Files)
                    .Include(p=>p.Group)
                  .LastOrDefaultAsync(p => p.GroupId == group));
            }
               return messages;

        }

        public async Task<List<Message>> GetPrivateRoomMessage(long userId)
        {
            var privatromsId=_chatContext.Messages

                .Where(p=>p.User_Id==userId&&p.ToUser_Id!=null)
                .DistinctBy(p=>p.ToUser_Id)
                .Select(p=>p.ToUser_Id);
            List<Message> messages = new List<Message>();
            foreach (var item in privatromsId)
            {
                messages.Add(await _chatContext.Messages
                          .Include(p => p.Files)
                          
                  .LastOrDefaultAsync(p => p.ToUser_Id == item));
            }
            return messages;
        }
    }
}
