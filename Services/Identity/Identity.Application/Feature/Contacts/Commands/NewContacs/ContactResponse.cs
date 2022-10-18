using Identity.Domain.User;

namespace Identity.Application.Feature.Contacts.Commands.NewContacs
{
    public class ContactResponse
    {
        public User Contact { get; set; }
        public string Name { get; set; }

    }
}
