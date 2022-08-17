using Application.WASM.Extentions;
using Application.WASM.Model;
using Application.WASM.Models;

namespace Application.WASM.Services
{
    public interface IChatService
    {
        public Task<GroupResponse> GetGroupById(string groupId);
    }
    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;

        public ChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GroupResponse> GetGroupById(string groupId)
        {
            var res = await _httpClient.GetAsync($"/Group/GetGroup/{groupId}");
            return await res.ReadContentAs<GroupResponse>();


        }
    }
}
