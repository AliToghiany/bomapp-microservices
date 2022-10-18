using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.GroupE
{
    public enum RoleOfJoin
    {
        /// <summary>
        /// بالاترین سطح دسترسی به گروه ها
        /// </summary>
        Owner,
        /// <summary>
        /// دسترسی ها توسط سازنده
        /// </summary>
        Admin,
        Custom
    }
}
