using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.MessageE
{
    public class File
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public Message Message { get; set; }
        public long Message_Id { get; set; }
    }
}
