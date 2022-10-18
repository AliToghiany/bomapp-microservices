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
        public string Id { get; set; }
        public string Message_Id { get; set; }
        public long User_Id { get; set; }
        public long Group_Id { get; set; }
        public long ToUser_Id { get; set; }
        public long Reply_To_MessageId { get; set; }
        public string Text { get; set; }
        public string Sticker_Id { get; set; }
        public string Gif_Id { get; set; }
        public List<FileDto> Files { get; set; }
  
    }
}
