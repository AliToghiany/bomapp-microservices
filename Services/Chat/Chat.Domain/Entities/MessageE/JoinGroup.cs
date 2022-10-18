using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.MessageE
{
    public class JoinGroup:BaseNotifMessage
    {
        public long InvitedBy { get; set; }
        public bool InviteByLink { get; set; }

        public virtual List<Message> Messages { get; set; }
    }
}
