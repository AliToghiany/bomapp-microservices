using Identity.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contracts.Repositories
{
    public interface IContactRepository
    {
        public Task NewRangeContacts(List<Contact> contacts);
        IEnumerable<Contact> GetContacts(long userId);
        Task<Contact> GetContact(long For, long With);
    }
}
