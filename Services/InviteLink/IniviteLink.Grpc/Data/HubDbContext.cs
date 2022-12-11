
using IniviteLink.Grpc.Entites;
using IniviteLink.Grpc.Services;
using MongoDB.Driver;

namespace InviteLink.Grpc.Data
{
    public class HubDbContext 
    {
        public HubDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var dataBase = client.GetDatabase("DatabaseSettings:DatabaseName");

            InviteLinks = dataBase.GetCollection<InviteLinkEntity>("DatabaseSettings:CollectionName");
       

        }

        public IMongoCollection<InviteLinkEntity> InviteLinks { get; }
      
    }
}
