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

       
    }
}
