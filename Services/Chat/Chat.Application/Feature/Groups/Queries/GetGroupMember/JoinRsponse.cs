using Chat.Domain.Entities.GroupE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Groups.Queries.GetGroupMember
{
    public class JoinRsponse
    {
        public long UserId { get; set; }
        public RoleOfJoin RoleOfJoinSetting { get; set; }
       //public string RoleName { get; set; }
    }
}
