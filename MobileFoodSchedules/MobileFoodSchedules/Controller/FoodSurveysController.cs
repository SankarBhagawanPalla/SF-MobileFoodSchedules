using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileFoodSchedules.Models;

namespace MobileFoodSchedules.Controller
{
    [Route("api/FoodSurvey/[controller]")]
    [ApiController]
    public class FoodSurveysController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public FoodSurveysController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        // GET: api/FoodSurveys
        [HttpGet]
        public ActionResult<IEnumerable<FoodSurvey>> GetFoodSurvey()
        {
            List<FoodSurvey> FoodSurvey = new List<FoodSurvey>();
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "FoodSurveys.txt");
            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                FoodSurvey fs = new FoodSurvey();
                fs.firstName = data[0];
                fs.lastName = data[1];
                fs.mobile = data[2];
                fs.email = data[3];
                fs.age = Int32.Parse(data[4]);
                fs.favouriteDish = data[5];
                fs.favouriteCuisine = data[6];
                fs.homeCountry = data[7];

                FoodSurvey.Add(fs);
            }
            file.Close();
            return FoodSurvey;
        }
    }
}

 
