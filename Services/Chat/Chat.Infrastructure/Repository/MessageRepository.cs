using Chat.Application.Contracts.Persisence;

using Chat.Infrastructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Chat.Domain.Entities.MessageE;
using File = Chat.Domain.Entities.MessageE.File;

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

        public Task<bool> ChckMessageForUser(long userId, long messageid)
        {
            throw new NotImplementedException();
        }

        public async Task<Message?> GetMessage(long messageid)
        {
            return await _chatContext
                .Messages
                .Include(p=>p.Files)
                .FirstOrDefaultAsync(p=>p.Id==messageid);

        }
        

        public async Task<bool> JoinInGroup(long groupId,long UserId)
        {
        var res=  await  _chatContext.Joins.FirstOrDefaultAsync(p=>p.GroupId==groupId&&p.UserId==UserId);
            if (res == null)
                return false;
            return true;
        }

        public Task<bool> RemoveMessage(long messageid)
        {
            throw new NotImplementedException();
        }

        public Task<List<long>> GetAllPrivateRoom(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Message>> GetGroupMessage(long userId)
        {
            var x = _chatContext.Messages.ToList();
                var gropsid = _chatContext.Joins
            
                    .Where(p => p.UserId == userId)
                    .Select(p => p.GroupId);
                List<Message> messages = new List<Message>();
                foreach (var group in gropsid)
                {
                    messages.Add(await _chatContext.Messages
                          .Include(p => p.Files)
                          .Include(p => p.Group)
                    .Include(p=>p.JoinGroup)
                        .LastAsync(p => p.GroupId == group));
                }
                return messages;
           
           
        }

        public async Task<List<Message>> GetPrivateRoomMessage(long userId)
        {
           
                var privatromsId = await _chatContext.Messages

                    .Where(p => p.User_Id == userId && p.ToUser_Id != null)
                    .Select(p => p.ToUser_Id).Distinct().ToListAsync();
                List<Message> messages = new List<Message>();
                foreach (var item in privatromsId)
                {
                   
                    messages.Add(await _chatContext.Messages
                              .Include(p => p.Files)
                              .OrderBy(p=>p.CreatedDate)
                      .LastAsync(p => p.ToUser_Id == item));
                }
                return messages;
           
           
        }

        public Task<bool> UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Message>?> GetMessageLastMessage(long lastMessageId)
        {
           var message=await _chatContext.Messages.FindAsync(lastMessageId);
            if (message!.GroupId!=null)
            {
                return await _chatContext
                    .Messages
                    .Where(p =>int.Parse(p.Message_Id) > int.Parse(message.Message_Id)).ToListAsync();
            }
            if (message.ToUser_Id != null)
            {
                return await _chatContext
                   .Messages
                   .Where(p=>p.ToUser_Id==message.User_Id||p.ToUser_Id==message.Id)
                   .Where(p => int.Parse(p.Message_Id) > int.Parse(message.Message_Id)).ToListAsync();
            }
            return null;
        }

        public async Task<List<Message>?> GetMessageFirstMessage(long lastMessageId)
        {

            var message = await _chatContext.Messages.FindAsync(lastMessageId);
            if (message!.GroupId != null)
            {
                return await _chatContext
                    .Messages
                    .Where(p=>p.GroupId==message.GroupId)
                    .Where(p => int.Parse(p.Message_Id) < int.Parse(message.Message_Id)).Take(300).ToListAsync();
            }
            if (message.ToUser_Id != null)
            {
                return await _chatContext
                   .Messages
                   .Where(p => (p.ToUser_Id == message.ToUser_Id && p.User_Id == message.User_Id)|| (p.User_Id == message.ToUser_Id && p.ToUser_Id == message.User_Id))
                   .Where(p => int.Parse(p.Message_Id) < int.Parse(message.Message_Id)).Take(300).ToListAsync();
            }
            return null;
        }

        public async Task<List<Message>> GetMessageFromGroup(long id)
        {
            return await _chatContext
                   .Messages
                   .Where(p => p.GroupId == id)
                   .Take(300).ToListAsync();
        }

        public async Task<List<Message>> GetMessageFromPrivate(long userId, long toUserId)
        {
            return await _chatContext
                   .Messages
                   .Where(p => (p.ToUser_Id == toUserId && p.User_Id == userId) || (p.User_Id == toUserId && p.ToUser_Id == userId))
                   .Take(300).ToListAsync();
        }
    }
}
