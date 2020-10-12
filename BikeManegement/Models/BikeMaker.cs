using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManegement.Models
{
    public class BikeMaker
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string MakerName { get; set; }




    }
}
