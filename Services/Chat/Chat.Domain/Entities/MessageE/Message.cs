using Chat.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.MessageE
{
    public class Message:BaseEntity
    {
        [Key]
       public long Id { get; set; }

        public string Message_Id { get; set; }

        public long? User_Id { get; set; }

        public long? GroupId { get; set; }

        public long? ToUser_Id { get; set; }
        public virtual Message ReplyMessage { get; set; }
        public long? ReplyMessageId { get; set; }

        public string Text { get; set; }

        public long? StickerId { get; set; }
        public long? JoinGroupId { get; set; }
        public virtual JoinGroup JoinGroup { get; set; }
        public long? GifId { get; set; }
        public virtual List<File> Files { get; set; }
        public virtual GroupE.Group Group { get; set; }
       
    }
}
