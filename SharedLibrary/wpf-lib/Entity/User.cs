using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lib.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? UserName { get; set; }
        public List<User> Message { get; set; }

        public List<ImageProfile> ImageProfiles { get; set; }       
    }
}
