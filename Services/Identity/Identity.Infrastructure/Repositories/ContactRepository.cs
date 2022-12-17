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
    public class ContactRepository : IContactRepository
    {
        private readonly IdentityDBContext _identityDBContext;

        public ContactRepository(IdentityDBContext identityDBContext)
        {
            _identityDBContext = identityDBContext;
        }

        public async Task<Contact?> GetContact(long For, long With)
        {
           
                return await _identityDBContext.Contacts.FirstOrDefaultAsync(p => p.ForUserId == For && p.WithUserId == With);
         }
         
            

        public IEnumerable<Contact> GetContacts(long userId)
        {
            return _identityDBContext.Contacts
                .Include(p=>p.WithUser)
                .ThenInclude(p=>p.UserImages)
                .Where(p => p.ForUserId == userId).ToList();
        }

        public async Task NewRangeContacts(List<Contact> contacts)
        {
            await _identityDBContext.Contacts.AddRangeAsync(contacts);
            await _identityDBContext.SaveChangesAsync();
            
        }
    }
}
