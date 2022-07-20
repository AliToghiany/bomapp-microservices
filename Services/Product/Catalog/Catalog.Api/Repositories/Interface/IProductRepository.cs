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
        ProductListResult GetProducts(Ordering ordering, string SearchKey, int PageSize, int Page, long? Catid);
        Task<Product> GetProduct(long id);

      

        Task<ResultDto<long>> CreateProduct(Product product, List<IFormFile> Upload);
        Task<ResultDto<long>> UpdateProduct(Product product, List<IFormFile> Upload);
        Task<ResultDto> DeleteProduct(long id);
    }
}
