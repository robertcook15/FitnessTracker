using FitnessTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FitnessTracker.Controllers
{
    public class ExerciseController : Controller
    {
        //this controller demonstrates CRUD

        private ApplicationDbContext _context;

        public ExerciseController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Exercise
        public ActionResult New()
        {
            WorkoutViewModel viewModel = new WorkoutViewModel()
            {
                Workout = new Workout()
            };
            return View("New", viewModel);
        }

        //SAVE is create and updated in one.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(WorkoutViewModel exercise)
        {
            //get currently user loged in throught the ASP.Net Users table         
            var currentUserId = User.Identity.GetUserId();            

            Workout userId = new Workout()
            {
                UserId = currentUserId
            };
            //adds user logged in to Workout table under UserId
            exercise.Workout.UserId = userId.UserId;                                              

            if (!ModelState.IsValid)
            {                
                return View("New");
            }
            //Createing
            if (exercise.Workout.Id == 0)            
                _context.Workout.Add(exercise.Workout);           
            else
            {
                //Updateing
                var exerciseInDb = _context.Workout.FirstOrDefault(e => e.Id == exercise.Workout.Id);

                exerciseInDb.ExerciseName = exercise.Workout.ExerciseName;
                exerciseInDb.Weight = exercise.Workout.Weight;
                exerciseInDb.Reps = exercise.Workout.Reps;
            }
            
            _context.SaveChanges();           

            return RedirectToAction("Index", "Exercise");
        } 
        
        //Reading       
        public ViewResult Index()
        {
            //populates the bmi table unique to the user logged in
            var currentUserId = User.Identity.GetUserId();

            var exercise = _context.Workout.Where(c => c.UserId == currentUserId);

            return View(exercise);
        }
        public ActionResult Details(int id)
        {
            var exercise = _context.Workout.FirstOrDefault(c => c.Id == id);

            if (exercise == null)
                return HttpNotFound();

            return View(exercise);
        }
        //Update
        public ActionResult Edit(int id)
        {
            var exercise = _context.Workout.SingleOrDefault(c => c.Id == id);

            if (exercise == null)
                return HttpNotFound();
            WorkoutViewModel viewModel = new WorkoutViewModel()
            {
                Workout = exercise
            };
            return View("New", viewModel);
        } 
        //Delete   
        public ActionResult Delete(int id)
        {
            Workout exercise = _context.Workout.Find(id);
            _context.Workout.Remove(exercise);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}