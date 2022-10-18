using Identity.Application.Feature.Users.Queries.GetUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Queries.GetUsers
{
    public class GetUsersQuery:IRequest<List<ResponseUser>>
    {
        public string SearchKey { get; set; }
        int Take { get; set; }
    }
}
