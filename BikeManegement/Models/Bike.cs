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

    
        [Required(ErrorMessage = "Provide Seller Name")]
        [StringLength(50)]
        public string SellerName { get; set; }


        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        [StringLength(50)]
        public string SellerEmail { get; set; }

        
        [Required(ErrorMessage = "Provide Phone No.")]
        [Phone]
        [StringLength(15)]
        public string SellerPhone { get; set; }

      
        [Required(ErrorMessage = "Provide Price")]
        [Range(1, 999999999, ErrorMessage = "Not with in the valid price range")]
        public int Price { get; set; }

        [Required(ErrorMessage ="Please select approprite currency")]
        public string Currency { get; set;}

    }
}
