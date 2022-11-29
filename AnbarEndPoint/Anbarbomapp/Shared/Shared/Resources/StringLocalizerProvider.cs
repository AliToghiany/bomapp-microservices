﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Anbarbomapp.Shared.Resources
{
    public static class StringLocalizerProvider
    {
        public static IStringLocalizer ProvideLocalizer(Type dtoType, IStringLocalizerFactory factory)
        {
            return factory.Create(dtoType.GetCustomAttribute<DtoResourceTypeAttribute>()?.ResourceType ?? typeof(AppStrings));
        }
    }
}