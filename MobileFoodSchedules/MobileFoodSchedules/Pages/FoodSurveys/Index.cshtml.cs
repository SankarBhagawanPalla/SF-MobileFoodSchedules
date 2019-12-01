using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MobileFoodSchedules.Models;

namespace MobileFoodSchedules.Pages.FoodSurveys
{
    public class IndexModel : PageModel
    {
        private readonly IHostingEnvironment _environment;

        public IndexModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IList<FoodSurvey> FoodSurvey = new List<FoodSurvey>(); 

        public void OnGet()
        {
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "FoodSurveys.txt");
            StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                FoodSurvey fs = new FoodSurvey();
                fs.firstName = data[0];
                fs.lastName = data[1];
                fs.mobile= data[2];
                fs.email = data[3];
                fs.age = Int32.Parse(data[4]);
                fs.favouriteDish= data[5];
                fs.favouriteCuisine = data[6];
                fs.homeCountry = data[7];

                FoodSurvey.Add(fs);
            }
            file.Close();
        }
    }
}
