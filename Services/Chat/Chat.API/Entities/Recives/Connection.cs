using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat.API.Entities.Recives
{
    public class Connection
    {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            public string ConnectionID { get; set; }
            public string UserAgent { get; set; }
            public bool Connected { get; set; }
            public long User_Id { get; set; }
            public string ClientId { get; set; }

    }
}
