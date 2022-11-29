using Anbarbomapp.Server.Api.Models.Account;
using Anbarbomapp.Shared.Dtos.Account;

namespace Anbarbomapp.Server.Api.Mappers
{
    public class AccountMapperConfiguration : Profile
    {
        public AccountMapperConfiguration()
        {
            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, EditUserDto>().ReverseMap();
            CreateMap<User, SignUpRequestDto>()
                .ReverseMap();
        }
    }
}