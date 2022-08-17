using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Common.Services.Utilities
{
    public class UserIdentity
    {
        

        public static long GetID(ClaimsPrincipal? user)
        {
            var userid = long.Parse((user.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value);
            return userid;
        }
        public static string GetIRole(ClaimsPrincipal? user)
        {
            var userid = (user.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;
            return userid;
        }
    }
}
