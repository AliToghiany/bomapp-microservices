using Identity.Application.Contracts.Repositories;
using Identity.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories
{
    internal class ContactRepository : IContactRepository
    {
        public Task<IEnumerable<Contact>> GetContacts(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> NewRangeContacts(List<Contact> contacts)
        {
            throw new NotImplementedException();
        }
    }
}
