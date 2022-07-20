using Chat.Domain.Entities.UserE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contracts.Persisence
{
    public interface IUserRepository
    {
        Task<User> GetUserById(long Id);
    }
}
