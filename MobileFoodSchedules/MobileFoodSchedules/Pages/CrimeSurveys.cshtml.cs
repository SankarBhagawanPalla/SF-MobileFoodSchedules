using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using readSurvey;

namespace MobileFoodSchedules.Pages
{
    public class CrimeSurveysModel : PageModel
    {
        public CrimeSurvey[] crimeSurveys;
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {


                string crimeSurveyString = webClient.DownloadString("https://smartenrollmentforcrimeresolution.azurewebsites.net/api/CrimeSurveys");
                crimeSurveys = CrimeSurvey.FromJson(crimeSurveyString);
                ViewData["crimeSurveys"] = crimeSurveys;

            }

        }
    }

}