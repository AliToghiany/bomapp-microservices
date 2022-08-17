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
        public string Id { get; protected set; }

        public string Message_Id { get; set; }

        public long? User_Id { get; set; }
        [ForeignKey("GroupId")]
        public string GroupId { get; set; }

        public long? ToUser_Id { get; set; }

        public string Reply_To_MessageId { get; set; }

        public string Text { get; set; }

        public string Sticker_Id { get; set; }

        public string Gif_Id { get; set; }
        public virtual List<File> Files { get; set; }
        public virtual GroupE.Group Group { get; set; }
       
    }
}
