using Chat.API.Entities.Recives;
using Chat.Application.Feature.Messages.Queries.GetMessage;

namespace Chat.API.Respositories.Interface
{
    public interface IHubRepository
    {
        public Task<bool> AddConnection(Connection connection);
        public Task<List<string>> GetConnectionOrAddQueue(List<long> userId, ResponseMessage responseMessage);
        public Task<List<MessageQueue>> GetMessagesQueue(long userId, string clientId);
        public Task DisableConnection(string coonectionId);
    }
}
