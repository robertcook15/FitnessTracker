using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessTracker.Models
{
    public class Workout
    {
        public int Id { get; set; }
        [Required] 
        [Display(Name = "Exercise Name")]       
        public string ExerciseName { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Reps { get; set; }
        public string UserId { get; set; }
    }
}