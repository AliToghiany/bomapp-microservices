using System.Collections.Generic;

namespace Chat.Application.Feature.Groups.Queries.GetGroup
{
    public class GroupResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string GroupName { get; set; }
        public List<GroupProfileResponse> GroupProfileResponses { get; set; }
    }
}
