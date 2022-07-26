using Identity.Application.Contracts.Repositories;
using Identity.Domain.User;
using Identity.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDBContext _identityDBContext;
        public UserRepository(IdentityDBContext identityDBContext)
        {
            _identityDBContext = identityDBContext;
        }

        public async Task<Confirm?> ConfirmCode(Guid id, string code)
        {
            var res = await _identityDBContext.Confirms.FindAsync(id);
            if (res==null || res.Code != code)
                return null;

            return res; 

        }

        public async Task<Confirm> CreateNewConfirm(Confirm confirm)
        {
            var res=await _identityDBContext.Confirms.AddAsync(confirm);
            await _identityDBContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<long> CreateUserByPhone(string phone)
        {
            var user = new User { PhoneNumber = phone };
           await _identityDBContext.Users.AddAsync(user);
           await _identityDBContext.UserRoles.AddAsync(new Microsoft.AspNetCore.Identity.IdentityUserRole<long>
            {
                UserId = user.Id,
                RoleId = 3
            });
           await _identityDBContext.SaveChangesAsync();
            return user.Id;
          
        }

        public Task EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> FindUserById(long id)
        {
            var res= await _identityDBContext.Users.FindAsync(id);
            return res;
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
