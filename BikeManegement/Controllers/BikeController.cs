using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeManegement.Data;
using BikeManegement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeManegement.Controllers
{

    [Authorize(Roles = "Admin,Executive")]
    public class BikeController : Controller
    {

        private readonly ApplicationDBContext _dbcontext;

        [BindProperty]
        public BikeViewModel bikeVM { get; set; }

        public BikeController(ApplicationDBContext dBContext)
        {

            _dbcontext = dBContext;

            bikeVM = new BikeViewModel()
            {
                BikeModels = _dbcontext.bikeModels.ToList(),
                BikeMakers = _dbcontext.BikeMakers.ToList(),
                Bike = new Models.Bike()

            };
        }



        public IActionResult Index()
        {
            var data = _dbcontext.Bikes.Include(m => m.BikeMaker).Include(m => m.BikeModel);
            return View(data.ToList());

        }

        //getMethod
        [HttpGet]
        public IActionResult Create()
        {
            return View(bikeVM);
        }

        [HttpPost ,ActionName("Create")]
        public IActionResult CreateBike()
        {
            if (!ModelState.IsValid)
            {
                return View(bikeVM);
            }
            _dbcontext.Bikes.Add(bikeVM.Bike);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
         
        }



    }
}
