﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Common
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> sources, int page, int pagesize, out int rowscount)
        {
            rowscount = sources.Count();
            return sources.Skip((page - 1) * pagesize).Take(pagesize);

        }
    }
}
