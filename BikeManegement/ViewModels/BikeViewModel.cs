using BikeManegement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManegement.ViewModels
{
    public class BikeViewModel
    {

        public Bike Bike { get; set; }

        public IEnumerable<BikeModel> BikeModels { get; set; }

        public IEnumerable<BikeMaker> BikeMakers { get; set; }

        public IEnumerable<SelectListItem> BikeMakersList(IEnumerable<BikeMaker> items)
        {
            List<SelectListItem> MakeList = new List<SelectListItem>();

            SelectListItem sli = new SelectListItem
            {
                Text = "---select----",
                Value = "0",
            };

            MakeList.Add(sli);
            foreach (BikeMaker bm in items)
            {
                sli = new SelectListItem
                {
                    Text = bm.Name,
                    Value = bm.Id.ToString()
                };
                MakeList.Add(sli);
            }
            return MakeList;

        }

        public IEnumerable<SelectListItem> BikeModelList(IEnumerable<BikeModel> items)
        {
            List<SelectListItem> BikeModelList = new List<SelectListItem>();

            SelectListItem Modellist = new SelectListItem
            {
                Text = "---select----",
                Value = "0",
            };

            BikeModelList.Add(Modellist);

            foreach (BikeModel bm in items)
            {
                Modellist = new SelectListItem
                {
                    Text = bm.Name,
                    Value = bm.Id.ToString()
                };
                BikeModelList.Add(Modellist);
            }
            return BikeModelList;
        }


    

    }

}
