using Chat.API.Entities.Recives;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Chat.API.Data
{
    public class HubDbContext 
    {
        public HubDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var dataBase = client.GetDatabase("DatabaseSettings:DatabaseName");

            MessageQueueDetails = dataBase.GetCollection<MessageQueueDetail>("MessageQueueDetails");
        MessageQueues = dataBase.GetCollection<MessageQueue>("MessageQueues");
            Connections= dataBase.GetCollection<Connection>("Connections");

        }

        public IMongoCollection<MessageQueueDetail> MessageQueueDetails { get; }
        public IMongoCollection<MessageQueue> MessageQueues { get; }
        public IMongoCollection<Connection> Connections { get; }
    }
}
