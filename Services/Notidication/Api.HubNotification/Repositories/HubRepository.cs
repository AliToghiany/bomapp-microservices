using Api.HubNotification.Data;
using Api.HubNotification.Entitiest;
using Api.HubNotification.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api.HubNotification.Repositories
{
    public class HubRepository : IHubRepositorycs
    {
        private readonly HubDbContext _dbContext;

        public HubRepository(HubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddConnection(Connection connection)
        {
            try {
                await _dbContext.Connections.AddAsync(connection);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public async Task<List<string>> GetEnableConnection(List<long> userId)
        {
            List<string> enableConnection = new List<string>();
            foreach (var item in userId)
            {
                var res = await _dbContext.Connections.FirstOrDefaultAsync(p => p.Connected == true && p.UserId == item);
                enableConnection.Add(res.ConnectionID);
            }
            return enableConnection;
        }
    }
}
