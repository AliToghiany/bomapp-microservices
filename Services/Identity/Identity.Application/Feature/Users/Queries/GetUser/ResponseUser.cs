namespace Identity.Application.Feature.Users.Queries.GetUser
{
    public class ResponseUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public List<ImagesProfileResponse> ImagesProfileResponses { get; set; }

    }
}
