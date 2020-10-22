using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManegement.Extensions
{
    public static class ReflectionExtension
    {

        public static string GetPropertyValue<T>(this T Item, string ProperyName)
        {
            return Item.GetType().GetProperty(ProperyName).GetValue(Item, null).ToString();
        }
    }
}
