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
    }
}
