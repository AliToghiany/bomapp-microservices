using Identity.Application.Feature.Users.Queries.GetUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Queries.GetUsers
{
    public record GetUsersQuery(string SearchKey,List<string> UserName, int Take, long UserId) :IRequest<GetUsersResponse>;
}
