using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lib.Entity
{
    public class ImageProfile
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }
    }
}
