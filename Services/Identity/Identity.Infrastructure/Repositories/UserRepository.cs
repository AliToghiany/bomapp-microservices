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

        public Task<bool> BlockUser(long userId, long blockedUser)
        {
            throw new NotImplementedException();
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
           
                var res = await _identityDBContext.Confirms.AddAsync(confirm);
                await _identityDBContext.SaveChangesAsync();
                return res.Entity;
           
        
        }

        public async Task<long> CreateUserByPhone(string phone)
        {
            try
            {
                var user = new User { PhoneNumber = phone };
               user=( await _identityDBContext.Users.AddAsync(user)).Entity;
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

        public async Task EditUser(User user)
        {
            _identityDBContext.Users.Update(user);
          await  _identityDBContext.SaveChangesAsync();
        }

        public async Task<User?> FindUserById(long id)
        {
            var res = await _identityDBContext.Users.Include(p => p.UserImages).FirstOrDefaultAsync(p=>p.Id==id);
            return res;
        }

        public async Task<User?> FindUserByPhone(string phone)
        {
            var res =await _identityDBContext.Users.FirstOrDefaultAsync(p=>p.PhoneNumber==phone);
       
            return res;
        }

        public IQueryable<User> GetUserBySearchKey(string searchKey)
        {
            return _identityDBContext.Users.Include(p=>p.UserImages).Where(p => (p.FirstName +" "+p.LastName).Contains(searchKey));
        }

        public async Task< IEnumerable<User>> GetUsersByUserName(List<string> userName)
        {
            List<User> users = new List<User>();
            foreach (var q in userName)
            {
                users.Add(await _identityDBContext.Users.FirstAsync(p => p.UserName == q));
            }
               
                
            
             
            return users;
        }

        public async Task<bool> IsFreeUserName(string userName,long userId)
        {
            return
              ! (await _identityDBContext.Users.AnyAsync(p => p.UserName == userName && p.Id != userId));
        }
    }
}
