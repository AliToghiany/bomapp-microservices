using Application.WASM.IndexDbEntities;
using Application.WASM.Models;

namespace Application.WASM.Repository.Interface
{
    public interface IChatRepository
    {
        Task<long> NewMessage(Message message);
        Task<bool> NewGroup(Group group);
        Task<long> NewPrivateRoom(MyPrivateRoom privateRoom);
        Task<bool> CheckGroup(string groupId);
        Task<long?> CheckPrivateRoom(long withUserId);
        Task<Message> NewMessageService(ResponseMessage message);
        Task<User?> CheckUser(long userId);
        Task<long> NewUser(User user);
        Task<List<RecentChat>> GetRecentChat();
        
    }
}
