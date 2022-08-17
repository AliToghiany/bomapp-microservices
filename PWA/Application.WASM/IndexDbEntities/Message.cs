using Application.WASM.Models;

namespace Application.WASM.IndexDbEntities
{
    public class Message
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsEdited { get; set; }
        public string MessageId { get; set; }
        public string Message_Id { get; set; }
         public long User_Id { get; set; }
        public string Group_Id { get; set; }
        public long? PrivateRoom_Id { get; set; }
        public string Reply_To_MessageId { get; set; }
        public string Text { get; set; }
        public string Sticker_Id { get; set; }
        public string Gif_Id { get; set; }
    }
}
