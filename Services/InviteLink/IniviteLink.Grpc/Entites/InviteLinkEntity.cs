using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IniviteLink.Grpc.Entites
{
    
    public class InviteLinkEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("InviteLink_Name")]
        public string InviteLink_Name { get; set; }
        [BsonElement("ServiceName")]
        public string ServiceName { get; set; }
    }
}
