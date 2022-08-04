using Chat.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.MessageE
{
    public class Message:BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; protected set; }
        public string Message_Id { get; set; }
        public long User_Id { get; set; }
        public string Group_Id { get; set; }
        public long ToUser_Id { get; set; }
        public string Reply_To_MessageId { get; set; }
        public string Text { get; set; }
        public string Sticker_Id { get; set; }
        public string Gif_Id { get; set; }
        public List<File> Files { get; set; }
    }
}
