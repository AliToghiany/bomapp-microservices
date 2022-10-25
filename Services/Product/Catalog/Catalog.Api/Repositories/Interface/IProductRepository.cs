using Catalog.Api.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories.Interface
{
    public interface IProductRepository
    {
        ProductListResult GetGames(Ordering ordering, string SearchKey, int PageSize, int Page, long? Catid);
     
        Task<GameResponse> GetGame(long id);

      

        Task<ResultDto<long>> CreateGame(Game product, List<IFormFile> Upload);
        Task<ResultDto<long>> UpdateGame(Game product, List<IFormFile> Upload);
        Task<ResultDto> DeleteGame(long id);
    }
}
