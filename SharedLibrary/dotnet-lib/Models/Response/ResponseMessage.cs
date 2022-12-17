using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Models.Response
{
    public class ResponseMessage
    {

        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsEdited { get; set; }
        public long Id { get; set; }
        public string Message_Id { get; set; }
        public long User_Id { get; set; }
        public long? GroupId { get; set; }
        public long? ToUser_Id { get; set; }
        public long? ReplyToMessageId { get; set; }
        public string Text { get; set; }
        public long? StickerId { get; set; }
        public long? GifId { get; set; }
        public List<FileDto> Files { get; set; }
    }
}
