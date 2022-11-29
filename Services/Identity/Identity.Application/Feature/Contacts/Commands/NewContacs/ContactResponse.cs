using Identity.Domain.User;

namespace Identity.Application.Feature.Contacts.Commands.NewContacs
{
    public class ContactResponse
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }

    }
    
}
