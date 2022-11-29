using Anbarbomapp.Server.Api.Models.Products;
using Anbarbomapp.Shared.Dtos.Products;

namespace Anbarbomapp.Server.Api.Mappers
{
    public class ProductMapperConfiguration : Profile
    {
        public ProductMapperConfiguration()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}