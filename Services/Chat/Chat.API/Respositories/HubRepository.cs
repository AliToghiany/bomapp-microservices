using Chat.API.Data;
using Chat.API.Entities.Recives;
using Chat.API.Hubs;
using Chat.API.Respositories.Interface;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Chat.API.Respositories
{
    public class HubRepository : IHubRepository
    {
        private readonly HubDbContext _dbContext;

        public HubRepository(HubDbContext dbContext)
        {
            _dbContext = dbContext;
     
        }

        public async Task<bool> AddConnection(Connection connection)
        {
            try
            {
                await _dbContext.Connections.InsertOneAsync(connection);
                
                return true;
            }
            catch
            {
                return false;
            }


        }

        public async Task DisableConnection(string coonectionId)
        {
            var connection = await _dbContext.Connections.Find(p => p.ConnectionID == coonectionId).FirstOrDefaultAsync();
            connection.Connected = false;
          await _dbContext
                 .Connections
                 .ReplaceOneAsync(filter: g => g.Id == connection.Id, replacement: connection);

            

        }

        public async Task<List<MessageQueue>> GetMessagesQueue(long userId,string clientId)
        {
            var mqd = await _dbContext.MessageQueueDetails.FindAsync(p => p.User_Id == userId&&!p.ClientsId.Any(p=>p==clientId));
            List<MessageQueue> messages = new List<MessageQueue>();
            foreach (var item in await mqd.ToListAsync())
            {
                var res =await _dbContext.MessageQueues.FindAsync(p=>p.Id==item.MessageQueueId);
                messages.AddRange(await res.ToListAsync());
            }

            await _dbContext.MessageQueueDetails.DeleteManyAsync(p => p.User_Id == userId);

            return messages;
        }

        public async Task<List<string>> GetConnectionOrAddQueue(List<long> userId, string dataMessage,string state)
        {
           
            MessageQueue messageQueue = new MessageQueue { DataNessage = dataMessage, Satate = state };
            await  _dbContext.MessageQueues.InsertOneAsync(messageQueue);
            List<MessageQueueDetail> messageListUser = new List<MessageQueueDetail>();
            List<string> connectionsid = new List<string>();
            foreach (var item in userId)
            {

                var res = await _dbContext.Connections.Find(p => p.Connected == true && p.User_Id == item).ToListAsync();
                var messagequedeatil = new MessageQueueDetail
                {
                    User_Id = item,
                    MessageQueueId = messageQueue.Id,
                    //AsGroupId=message.Group_Id,
                    //AsUserId=message.ToUser_Id

                };
                foreach (var connectionUser in res)
                {
                    connectionsid.Add(connectionUser.ConnectionID);
                    messagequedeatil.ClientsId.Add(connectionUser.ClientId);
                }
                messageListUser.Add(messagequedeatil);
               
               


              
            }
           
            return connectionsid;
        }
    }
}
