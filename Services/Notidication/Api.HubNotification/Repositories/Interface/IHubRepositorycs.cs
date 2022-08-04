using Api.HubNotification.Entitiest;

namespace Api.HubNotification.Repositories.Interface
{
    public interface IHubRepositorycs
    {
        public Task<bool> AddConnection(Connection connection);
        public Task<List<string>> GetEnableConnection(List<long> userId,string datajson);
    }
}
