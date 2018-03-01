using FitnessTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FitnessTracker.Controllers
{    
    
    public class BmiController : Controller
    {
        public const int ImperalBmiConversion = 703;

        private ApplicationDbContext _context;

        public object EnityState { get; private set; }

        public BmiController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult CalculateBmi()
        {
            BmiViewModel viewModel = new BmiViewModel()
            {
                BmiModel = new BmiModel()
            };
            return View("CalculateBmi", viewModel);
        }
        public ActionResult Save(BmiViewModel bmi)
        {
            //get currently user loged in throught the ASP.Net Users table
            var currentUserId = User.Identity.GetUserId();

            BmiModel userId = new BmiModel()
            {
                UserId = currentUserId
            };
            //adds user logged in to BmiModel table under UserId
            bmi.BmiModel.UserId = userId.UserId;

            if (!ModelState.IsValid)
            {
                return View("CalculateBmi");
            }

            if (bmi.BmiModel.Id == 0)
            {
                _context.BmiModel.Add(bmi.BmiModel);                      
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "BMI");

        }
        // GET: Bmi
        public ActionResult Index()
        {
            //populates the bmi table unique to the user logged in
            var currentUserId = User.Identity.GetUserId();

            var bmiModel = _context.BmiModel.Where(c => c.UserId == currentUserId);

            return View(bmiModel);
        }
        public ActionResult Details(int id)
        {
            var bmiModel = _context.BmiModel.FirstOrDefault(c => c.Id == id);

            if (bmiModel == null)
                return HttpNotFound();

            return View(bmiModel);
        }
    }
}