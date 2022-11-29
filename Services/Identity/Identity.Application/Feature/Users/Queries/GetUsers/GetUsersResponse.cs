using Identity.Application.Feature.Users.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Feature.Users.Queries.GetUsers
{
    public class GetUsersResponse
    {
        public List<ResponseUser> Users { get; set; }
    }
}
