using Application.WASM.IndexDbEntities;
using IndexedDB.Blazor;
using Microsoft.JSInterop;

namespace Application.WASM.Data
{
    public class ChatDb : IndexedDb
    {
        public ChatDb(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
        public IndexedSet<User> Users { get; set; }
        public IndexedSet<Group> Groups { get; set; }
        public IndexedSet<IndexDbEntities.File> Files { get; set; }
        public IndexedSet<Message> Messages { get; set; }
        public IndexedSet<MyPrivateRoom> MyPrivateRooms { get; set; }
        public IndexedSet<GroupProfile> GroupProfiles { get; set; }


    }
}
