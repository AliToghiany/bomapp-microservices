using Chat.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.UserE
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public List<ImageProfile> Images { get; set; }

    }
    public class ImageProfile
    {
        public long ID { get; set; }
        public string PathName { get; set; }
        public virtual User User { get; set; }
        public long User_Id { get; set; }
    }
}
