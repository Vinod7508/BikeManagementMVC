using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManegement.Extensions
{
    public static class DropDownExtension
    {

        public  static IEnumerable<SelectListItem> ToselectListItems<T>(this IEnumerable<T> Items)
        {
            List<SelectListItem> DropdownList = new List<SelectListItem>();

            SelectListItem sli = new SelectListItem
            {
                Text = "---select----",
                Value = "0",
            };
            DropdownList.Add(sli);
            foreach (var Item in Items)
            {
                sli = new SelectListItem
                {
                    //Text = Item.GetType().GetProperty("Name").GetValue(Item, null).ToString(),
                    //Value = Item.GetType().GetProperty("Id").GetValue(Item, null).ToString(),

                    Text = Item.GetPropertyValue("Name"),
                    Value = Item.GetPropertyValue("Id")

                };
                DropdownList.Add(sli);
            }
            return DropdownList;

        }
    }
}
