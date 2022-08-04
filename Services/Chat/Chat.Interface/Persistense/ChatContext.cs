using Chat.Domain.Entities.GroupE;
using Chat.Domain.Entities.MessageE;

using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Persistense
{
    public class ChatContext
    {
        public ChatContext(string connection,string database,string messagecollection,string filecollection,string groupcollection,string groupbanusercollection,string groupprofilecollection,string joincollection)
        {
            var client = new MongoClient(connection);
            var dataBase = client.GetDatabase(database);

            Messages = dataBase.GetCollection<Message>(messagecollection);
            Files = dataBase.GetCollection<File>(filecollection);
            Groups = dataBase.GetCollection<Group>(groupcollection);
            GroupBanUsers = dataBase.GetCollection<GroupBanUser>(groupbanusercollection);
            GroupProfiles = dataBase.GetCollection<GroupProfile>(groupprofilecollection);
            Joins = dataBase.GetCollection<Join>(joincollection);
          

        }

        public IMongoCollection<Message> Messages { get; }
        public IMongoCollection<File> Files { get; } 
        public IMongoCollection<Group> Groups { get; }
        public IMongoCollection<GroupBanUser> GroupBanUsers { get; }
        public IMongoCollection<GroupProfile> GroupProfiles { get; }
        public IMongoCollection<Join> Joins { get; }
    }
}
