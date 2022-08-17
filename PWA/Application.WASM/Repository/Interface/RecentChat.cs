using Application.WASM.IndexDbEntities;

namespace Application.WASM.Repository.Interface
{
    public class RecentChat
    {
        public Group Group { get; set; }
        public MyPrivateRoom MyPrivateRoom { get; set; }
        public Message Message { get; set; }
        
    }
}