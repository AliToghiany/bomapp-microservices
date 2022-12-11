using dotnet_lib.Models;
using dotnet_lib.Models.Response.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Services.Interface
{
    public interface ISearchService
    {
        public Task<ResultDto<AppResponseChatSearch>> SearchChatAsync(string searchKey);
    }
}
