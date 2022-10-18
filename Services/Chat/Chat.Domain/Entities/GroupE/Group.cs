using Chat.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.GroupE
{
    public class Group:BaseEntity
    {

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string GroupName { get; set; }
        public virtual List<GroupProfile> GroupProfiles { get; set; }
        public virtual List<Join> Joins { get; set; }
        public virtual List<MessageE.Message> Messages { get; set; }
        public virtual List<GroupBanUser> GroupBanUsers { get; set; }

    }
}
