using Identity.Application.Contracts.Repositories;
using Identity.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<Confirm> ConfirmCode(Guid id, string code)
        {
            throw new NotImplementedException();
        }

        public Task<Confirm> CreateNewConfirm(Confirm confirm)
        {
            throw new NotImplementedException();
        }

        public Task<long> CreateUserByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public Task EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindUserById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindUserByPhone(string code)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsFreeUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
