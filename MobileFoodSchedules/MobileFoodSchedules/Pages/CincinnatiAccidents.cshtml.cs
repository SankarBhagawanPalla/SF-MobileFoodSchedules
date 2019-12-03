using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Accidents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MobileFoodSchedules.Pages
{
    public class CincinnatiAccidentsModel : PageModel
    {
        public CincinnatiAccident[] cincinnatiAccidents;
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {


                string cincinnatiAccidentsString = webClient.DownloadString("https://cincinnatiaccidents.azurewebsites.net/api/accidents/downtown");
                cincinnatiAccidents = CincinnatiAccident.FromJson(cincinnatiAccidentsString);
                ViewData["cincinnatiAccidents"] = cincinnatiAccidents;

            }

        }
    }
}