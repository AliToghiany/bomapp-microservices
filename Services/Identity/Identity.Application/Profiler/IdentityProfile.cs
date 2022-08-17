using AutoMapper;
using Identity.Application.Feature.Users.Command.ConfirmUser;
using Identity.Application.Feature.Users.Queries.GetUser;
using Identity.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Profiler
{
    public class IdentityProfile:Profile
    {
        public IdentityProfile()
        {
            CreateMap<Confirm, ConfirmUserCommand>().ReverseMap();
            CreateMap<User, ResponseUser>();
        }
    }
}
