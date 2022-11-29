using Anbarbomapp.Server.Api.Models.Categories;
using Anbarbomapp.Shared.Dtos.Categories;

namespace Anbarbomapp.Server.Api.Mappers
{
    public class CategoryMapperConfiguration : Profile
    {
        public CategoryMapperConfiguration()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}