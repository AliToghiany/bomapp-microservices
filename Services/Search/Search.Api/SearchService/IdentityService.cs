using System.Net.Http.Headers;

namespace Search.Api.SearchService
{
    public class IdentityService
    {
        private readonly HttpClient httpClient;

        public IdentityService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<string?> GetIdentityUserSearch(string searchKey,string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ",""));
            var userSearch = await this.httpClient.GetAsync($"/user/GetUsersBySearch?shearchKey={searchKey}");
            if (userSearch.IsSuccessStatusCode)
                return await userSearch.Content.ReadAsStringAsync();
            else
                return null;

        }
    }
}
