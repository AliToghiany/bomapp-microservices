using Identity.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contracts.Repositories
{
    public interface IUserReposirory
    {
        Task<Confirm> CreateNewConfirm(Confirm confirm);
        Task<Confirm> ConfirmCode(Guid id,string code);
        Task<User> FindUserByPhone(string code);
        Task<long> CreateUserByPhone(string phone);
        Task<User> FindUserById(long id);
        Task<bool> IsFreeUserName(string userName);
        Task EditUser(User user);
    }
}
