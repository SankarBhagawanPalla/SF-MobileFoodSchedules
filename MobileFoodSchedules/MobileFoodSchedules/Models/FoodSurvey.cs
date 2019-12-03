using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileFoodSchedules.Models
{
    public class FoodSurvey
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string lastName { get; set; }
        [Display(Name = "Mobile")]
        [Required]
        public string mobile { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string email { get; set; }
        [Display(Name = "Age")]
        [Required]
        public int age { get; set; }
        [Display(Name = "Favourite Dish")]
        [Required]
        public string favouriteDish { get; set; }
        [Display(Name = "Favourite Cuisine")]
        [Required]
        public string favouriteCuisine { get; set; }
        [Display(Name = "Home Country")]
        [Required]
        public string homeCountry { get; set; }
    }
}
