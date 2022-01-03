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

    //[Authorize(Roles = "Admin,Executive")]
    public class BikeController : Controller
    {

        private readonly ApplicationDBContext _dbcontext;

        [BindProperty]
        public BikeViewModel BikeVM { get; set; }

        public BikeController(ApplicationDBContext dBContext)
        {

            _dbcontext = dBContext;

            BikeVM = new BikeViewModel()
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
            return View(BikeVM);
        }

        [HttpPost ,ActionName("Create")]
        public IActionResult CreateBike()
        {
            if (!ModelState.IsValid)
            {
                BikeVM.BikeMakers = _dbcontext.BikeMakers.ToList();
                BikeVM.BikeModels = _dbcontext.bikeModels.ToList();
                return View(BikeVM);
            }
            _dbcontext.Bikes.Add(BikeVM.Bike);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
         
        }




        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Bike = _dbcontext.Bikes.Find(id);
            if (Bike == null)
            {
                return NotFound();
            }
            _dbcontext.Bikes.Remove(Bike);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            BikeVM.Bike = _dbcontext.Bikes.SingleOrDefault(b => b.Id == id);

            //here i am getting a asscociated model
            BikeVM.BikeModels = _dbcontext.bikeModels.Where(m => m.BikeMakerId == BikeVM.Bike.BikeMakerID);

            if (BikeVM.Bike == null)
            {
                return NotFound();
            }
            return View(BikeVM);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                BikeVM.BikeMakers = _dbcontext.BikeMakers.ToList();
                BikeVM.BikeModels = _dbcontext.bikeModels.ToList();
                return View(BikeVM);
            }
            _dbcontext.Bikes.Update(BikeVM.Bike);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
