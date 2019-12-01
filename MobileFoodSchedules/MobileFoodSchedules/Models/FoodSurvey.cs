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
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Mobile")]
        public string mobile { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Age")]
        public int age { get; set; }
        [Display(Name = "Favourite Dish")]
        public string favouriteDish { get; set; }
        [Display(Name = "Favourite Cuisine")]
        public string favouriteCuisine { get; set; }
        [Display(Name = "Home Country")]
        public string homeCountry { get; set; }
    }
}
