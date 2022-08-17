using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Chat.API.Entities.Recives
{
    public class MessageQueueDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("User_Id")]
        public long User_Id { get; set; }
        [BsonElement("messageQueueId")]
        public string MessageQueueId { get; set; }
        [BsonElement("clientId")]
        public List<string> ClientId { get; set; }
        public string AsGroupId { get; set; }
        public long AsUserId { get; set; }
   
         

    }
    public class MessageQueue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string DataNessage { get; set; }

        public string Satate { get; set; }
    }
}
