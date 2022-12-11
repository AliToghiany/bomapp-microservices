using Chat.Application.Feature.Groups.Queries.GetGroup;
using System;
using System.Collections.Generic;

namespace Chat.Application.Feature.Messages.Queries.GetMessage
{
    public class ResponseMessage
    {
        public DateTime CreatedDate { get; set; } 
        public DateTime? LastModifiedDate { get; set; }
        public bool IsEdited { get; set; }
        public int Id { get; set; }
        public string Message_Id { get; set; }
        public long User_Id { get; set; }
        public long? GroupId { get; set; }
        public long? ToUser_Id { get; set; }
        public long? ReplyToMessageId { get; set; }
        public string Text { get; set; }
        public int? StickerId { get; set; }
        public int? GifId { get; set; }
        public List<FileDto> Files { get; set; }
  
    }
}
