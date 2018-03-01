using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessTracker.Models
{
    public class BmiModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Enter weight in lbs")]
        public decimal Weight { get; set; }
        [Required]
        [Display(Name = "Enter height in inches")]
        public decimal Height { get; set; }
        public decimal BmiResult
        {
            get
            {
                return Math.Round((Weight * 703) / (Height * Height), 2); 
            }
        }
        public string UserId { get; set; }
    }
}