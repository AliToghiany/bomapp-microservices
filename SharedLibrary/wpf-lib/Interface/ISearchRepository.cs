using dotnet_lib.Models;
using dotnet_lib.Models.Response.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lib.Interface
{
    public interface ISearchRepository
    {
        Task<ResultDto<AppResponseChatSearch>> GetLastSearch();
    }
}
