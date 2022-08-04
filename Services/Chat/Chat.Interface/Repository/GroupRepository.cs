using Chat.Application.Contracts.Persisence;
using Chat.Domain.Entities.GroupE;
using Chat.Infrastructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Chat.Infrastructure.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ChatContext _chatContext;

        public GroupRepository(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }
        public async Task<bool> CheckBanInGroup(long UserId, string GroupId)
        {
            var res =await (await _chatContext.GroupBanUsers.FindAsync(p => p.Group_Id == GroupId && p.User_Id == UserId)).FirstOrDefaultAsync();
            if (res == null)
                return false;
            return true;
        }

        public async Task<long> GetCountOfMessageGroup(string GroupId)
        {
            return await _chatContext.Messages.CountDocumentsAsync(p=>p.Group_Id==GroupId);
        }

        public async Task<Group> GetGroupById(string Id)
        {
            return await(await _chatContext.Groups.FindAsync(p => p.Id == Id)).FirstOrDefaultAsync();
        }

        
    }
}
