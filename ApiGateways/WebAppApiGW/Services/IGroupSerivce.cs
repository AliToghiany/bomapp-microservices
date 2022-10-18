using WebAppApiGW.Extentions;
using WebAppApiGW.Models;

namespace WebAppApiGW.Services
{
    public interface IGroupSerivce
    {
        Task<List<GroupResponse>> GetGroups(string searchKey,int page, int pageSize);
    }
    public class GroupSerivce : IGroupSerivce
    {
        private readonly HttpClient _httpClient;

        public GroupSerivce(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GroupResponse>> GetGroups(string searchKey, int page, int pageSize)
        {
            var res = await _httpClient.GetAsync($"/GetGroups/{searchKey}/{page}/{pageSize}");
            return await res.ReadContentAs<List<GroupResponse>>();
        }
    }
}
