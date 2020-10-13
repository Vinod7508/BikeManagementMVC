using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeManegement.Data;
using BikeManegement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeManegement.Controllers
{
    public class BikeMakerController : Controller
    {

        private readonly ApplicationDBContext _dbcontext;


        public BikeMakerController(ApplicationDBContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public IActionResult Index()
        {
            return View(_dbcontext.BikeMakers.ToList());
        }




        //HTTP Get Method
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(BikeMaker bm)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.BikeMakers.Add(bm);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(bm);

        }



        //HTTP Get Method
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bikeMaker = _dbcontext.BikeMakers.Find(id);
            if (bikeMaker == null)
            {
                return NotFound();
            }

            return View(bikeMaker);
        }

        [HttpPost]
        public IActionResult Edit(BikeMaker bm)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.BikeMakers.Update(bm);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(bm);
        }





        [HttpPost]
        public IActionResult Delete(int id)
        {
            var maker = _dbcontext.BikeMakers.Find(id);
            if (maker == null)
            {
                return NotFound();
            }
            _dbcontext.BikeMakers.Remove(maker);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
