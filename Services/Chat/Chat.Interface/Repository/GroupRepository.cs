using Chat.Application.Contracts.Persisence;
using Chat.Domain.Entities.GroupE;
using Chat.Infrastructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
namespace Chat.Infrastructure.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ChatDbContext _chatContext;

        public GroupRepository(ChatDbContext chatContext)
        {
            _chatContext = chatContext;
        }
        public async Task<bool> CheckBanInGroup(long UserId, string GroupId)
        {
            var res =await _chatContext.GroupBanUsers.FirstOrDefaultAsync(p=>p.UserId==UserId&&p.Group_Id==GroupId);
            if (res == null)
                return false;
            return true;
        }

        public Task<List<Group>> GetAllGroupByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<long> GetCountOfMessageGroup(string GroupId)
        {
            return await _chatContext.Messages.Where(p => p.GroupId == GroupId).LongCountAsync();
        }

        public async Task<Group> GetGroupById(string Id)
        {
            return await _chatContext.Groups.Include(p=>p.GroupProfiles).FirstOrDefaultAsync(p=>p.Id==Id);
        }

        public async Task<List<long>> GetMemberOfGroup(string groupId)
        {
            var group =await _chatContext.Groups.Include(p => p.Joins).FirstOrDefaultAsync(p => p.Id == groupId);
            return group.Joins.Select(p => p.UserId).ToList();
        }

        public async Task<bool> JoinInGroup(string groupId, long UserId)
        {
            return await _chatContext.Joins.AnyAsync(p => p.GroupId == groupId && p.UserId == UserId);
        }
    }
}
