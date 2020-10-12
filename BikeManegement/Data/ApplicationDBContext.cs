using BikeManegement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManegement.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {     
        }


        public DbSet<BikeMaker> BikeMakers { get; set; }
        public DbSet<BikeModel> bikeModels { get; set; }

    }
}
