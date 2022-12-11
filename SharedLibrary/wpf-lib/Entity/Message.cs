using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lib.Entity
{
    public class Message
    {
        [Key]
        public long Id { get; set; }
        public string Message_Id { get; set; }
        public long? UserId { get; set; }
        public virtual User User { get; set; }  
        public long? GroupId { get; set; }
        public long? ToUserId { get; set; }
        public virtual User ToUser { get; set; }
        public virtual Message ReplyMessage { get; set; }
        public long? ReplyMessageId { get; set; }
        public string Text { get; set; }
        public virtual List<File> Files { get; set; }

    }
}
