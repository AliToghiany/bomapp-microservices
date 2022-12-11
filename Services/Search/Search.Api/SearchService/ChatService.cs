namespace Search.Api.SearchService
{
    public class ChatService
    {
        private readonly HttpClient httpClient;

        public ChatService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<string?> GetChatGroupSearch(string searchKey)
        {
            var userSearch = await this.httpClient.GetAsync("/group/GetUsersBySearch");
            if (userSearch.IsSuccessStatusCode)
                return await userSearch.Content.ReadAsStringAsync();
            else
                return null;

        }
    }
}
