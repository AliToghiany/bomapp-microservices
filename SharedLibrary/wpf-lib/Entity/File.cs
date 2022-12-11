using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lib.Entity
{
    public class File
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public long MessageId { get; set; }
    }
}
