﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManegement.Models
{
    public class BikeModel
    {

        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string ModelName { get; set; }

        public BikeMaker BikeMaker { get; set; }

        public int BikeMakerId { get; set; }
    }
}