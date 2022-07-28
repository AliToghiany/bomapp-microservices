using Identity.Application.Contracts.Repositories;
using Identity.Domain.User;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
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
            if (res == null)
                return null;

            var confirms =_identityDBContext.Confirms.Where(p => p.Phone == res.Phone && p.IsUsed == false);
            if (confirms == null)
                return null;
            var confirm=await confirms.FirstOrDefaultAsync(p=>p.Code == code);
            if (confirm == null)
                return null;
            confirm.IsUsed = true;
            _identityDBContext.SaveChanges();

            return confirm; 

        }

        public async Task<Confirm> CreateNewConfirm(Confirm confirm)
        {
            var res=await _identityDBContext.Confirms.AddAsync(confirm);
            await _identityDBContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<long> CreateUserByPhone(string phone)
        {
            try
            {
                var user = new User { PhoneNumber = phone };
                await _identityDBContext.Users.AddAsync(user);
                await _identityDBContext.SaveChangesAsync();
                await _identityDBContext.UserRoles.AddAsync(new Microsoft.AspNetCore.Identity.IdentityUserRole<long>
                {
                    UserId = user.Id,
                    RoleId = 3
                });
                await _identityDBContext.SaveChangesAsync();
                return user.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
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

        public async Task<User?> FindUserByPhone(string phone)
        {
            var res =await _identityDBContext.Users.FirstOrDefaultAsync(p=>p.PhoneNumber==phone);
            return res;
        }

        public Task<bool> IsFreeUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
