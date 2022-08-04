using Chat.Domain.Entities.GroupE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contracts.Persisence
{
    public interface IGroupRepository
    {
        Task<Group> GetGroupById(string Id);
        Task<bool> CheckBanInGroup(long UserId, string GroupId);
        Task<long> GetCountOfMessageGroup(string GroupId);
        Task<bool> JoinInGroup(string groupId, long UserId);
    }
}
