using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeManegement.Data;
using BikeManegement.Models;
using BikeManegement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeManegement.Controllers
{
    //[Authorize(Roles = "Admin,Executive")]
    public class BikeModelController : Controller
    {

        private readonly ApplicationDBContext _dbcontext;


        [BindProperty]
        public Bike_ModelViewModel BMViewmodel { get; set; }

        public BikeModelController(ApplicationDBContext dBContext)
        {
            _dbcontext = dBContext;
            BMViewmodel = new Bike_ModelViewModel()
            {

                BikeModel = new Models.BikeModel(),
                BikeMakers = _dbcontext.BikeMakers.ToList()

            };
        }


        public IActionResult Index()
        {
            var data = _dbcontext.bikeModels.Include(m => m.BikeMaker);
            return View(data.ToList());

        }


        public IActionResult Create()
        {
            return View(BMViewmodel);
        }




        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateModel()
        {
            if (!ModelState.IsValid)
            {
                return View(BMViewmodel);
            }
          
            _dbcontext.bikeModels.Add(BMViewmodel.BikeModel);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        //HTTP Get Method
        [HttpGet]
        public IActionResult Edit(int id)
        {



            BMViewmodel.BikeModel = _dbcontext.bikeModels.Include(m => m.BikeMaker).SingleOrDefault(m => m.Id == id);

            if (BMViewmodel.BikeModel == null)
            {
                return NotFound();
            }

            return View(BMViewmodel);
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {

            BikeModel data = _dbcontext.bikeModels.Find(id);
            

            if(data == null)
            {
                return NotFound();
            }
            _dbcontext.bikeModels.Remove(data);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }




        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditModel()
        {
            if (!ModelState.IsValid)
            {
                return View(BMViewmodel);
            }


            _dbcontext.Update(BMViewmodel.BikeModel);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        [AllowAnonymous]
        [HttpGet("api/models/{BikeMakerID}")]
        public IEnumerable<BikeModel> BikeModels(int BikeMakerID)
        {
            return _dbcontext.bikeModels.ToList()
                 .Where(m => m.BikeMakerId == BikeMakerID);
        }

        




    }

}
