using dotnet_lib.Models;
using dotnet_lib.Models.Response;
using dotnet_lib.Models.Response.Search;
using dotnet_lib.Services.Interface;
using Newtonsoft.Json;

namespace dotnet_lib.Services
{
    public class SearchService : BaseService,ISearchService
    {


        public SearchService(HttpClient httpClient):base(httpClient)
        {
         
        }

        public async Task<ResultDto<AppResponseChatSearch>> SearchChatAsync(string searchKey)
        {
         var res=  await _httpClient.GetAsync($"/Search/SearchChat?searchKey={searchKey}");
            var responseDto = await res.ToResultdto<ResponseChatSearch>();
            if (!responseDto.IsSuccess)
            {
                return new ResultDto<AppResponseChatSearch>
                {
                    IsSuccess = false,
                    Message = responseDto.Message,
                    StatusCode = responseDto.StatusCode
                };
            }
            return new ResultDto<AppResponseChatSearch>
            {
                IsSuccess = true,
                Data = new AppResponseChatSearch
                {
                    ResponseUsers = JsonConvert.DeserializeObject<RR>(responseDto.Data.User.UserResponse).Users
                }
            };

        }
    }
    class RR
    {
        public List<ResponseUser> Users { get; set; }
    }
}
