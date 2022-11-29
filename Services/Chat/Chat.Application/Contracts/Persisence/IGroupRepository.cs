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
        Task<Group> GetGroupById(long Id);
        Task<bool> CheckBanInGroup(long UserId, long GroupId);
        Task<long> GetCountOfMessageGroup(long GroupId);
        Task<bool> JoinInGroup(long groupId, long UserId);
        Task<List<Join>> GetMemberOfGroup(long groupId);
        Task<List<Group>> GetAllGroupByUserId(long userId);
        IQueryable<Group> GetGroups();
        Task<bool> CheckGroupName(string GroupName);
        Task<Group> NewGroup(Group group);
        Task CreateImageGroup(GroupProfile groupProfile);
    }
}
