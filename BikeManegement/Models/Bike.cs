using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManegement.Models
{
    public class Bike
    {

        public int Id { get; set; }

        public BikeMaker BikeMaker { get; set; }

        public int BikeMakerID { get; set; }

        public BikeModel BikeModel { get; set; }

        public int BikeModelID { get; set; }


        [Required]
        public int Year { get; set; }

        [Required]
        public int Mileage { get; set; }

        public string Features { get; set; }

        [Required]
        public string SellerName { get; set; }

        public string SellerEmail { get; set; }

        [Required]
        public string SellerPhone { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Currency { get; set;}

    }
}
