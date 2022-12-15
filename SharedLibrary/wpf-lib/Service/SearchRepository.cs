using dotnet_lib.Models;
using dotnet_lib.Models.Response.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lib.Interface;

namespace wpf_lib.Service
{
    public class SearchRepository : ISearchRepository
    {
        public Task<ResultDto<AppResponseChatSearch>> GetLastSearch()
        {
            throw new NotImplementedException();
        }
    }
}
