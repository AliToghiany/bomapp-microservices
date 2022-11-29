using Identity.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<Confirm> CreateNewConfirm(Confirm confirm);
        Task<Confirm?> ConfirmCode(Guid id,string code);
        Task<User?> FindUserByPhone(string phone);
        Task<long> CreateUserByPhone(string phone);
        Task<User?> FindUserById(long id);
        Task<bool> IsFreeUserName(string userName,long userId);
        Task EditUser(User user);
        Task<bool> BlockUser(long userId, long blockedUser);
        IQueryable<User> GetUserBySearchKey(string searchKey);
    }
}
