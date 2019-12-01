using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileFoodSchedules.Models;

namespace MobileFoodSchedules.Pages.FoodSurveys
{
    public class CreateModel : PageModel
    {
        private readonly IHostingEnvironment _environment;
        public CreateModel( IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FoodSurvey FoodSurvey { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string survey = FoodSurvey.firstName + "," + FoodSurvey.lastName + "," + FoodSurvey.mobile + "," + FoodSurvey.email + "," + FoodSurvey.age + "," + FoodSurvey.favouriteDish + "," + FoodSurvey.favouriteCuisine + "," + FoodSurvey.homeCountry;
            string path = Path.Combine(_environment.ContentRootPath, "FoodSurveys.txt");
            
            System.IO.File.AppendAllText(path, survey + Environment.NewLine);
            
            return RedirectToPage("./Index");
        }
    }
}