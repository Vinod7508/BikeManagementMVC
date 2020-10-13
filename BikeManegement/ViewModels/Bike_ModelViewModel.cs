using BikeManegement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManegement.ViewModels
{
    public class Bike_ModelViewModel
    {

        public BikeModel BikeModel { get; set; }

        public IEnumerable<BikeMaker> BikeMakers { get; set; }

        public IEnumerable<SelectListItem> CBikeMakers(IEnumerable<BikeMaker> items)
        {
            List<SelectListItem> MakeList = new List<SelectListItem>();

            SelectListItem sli = new SelectListItem
            {
                Text = "---select----",
                Value = "0",
            };
            MakeList.Add(sli);
            foreach(BikeMaker bm in items)
            {
                sli = new SelectListItem
                {
                    Text = bm.MakerName,
                    Value = bm.Id.ToString()
                };
                MakeList.Add(sli);
            }
            return MakeList;

        }
    }
}
