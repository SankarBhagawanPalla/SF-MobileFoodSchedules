using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;
using QuickTypee;

namespace MobileFoodSchedules.Pages
{
    public class VendorPermissionsModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                String permitjsonString = webClient.DownloadString("https://data.sfgov.org/resource/rqzj-sfat.json");
                var mobileFoodPermits = MobileFoodPermit.FromJson(permitjsonString);
                ViewData["MobileFoodPermits"] = mobileFoodPermits;


                String schedulesjsonnString = webClient.DownloadString("https://data.sfgov.org/resource/jjew-r69b.json");
                var mobileFoodSchedules = MobileFoodSchedule.FromJson(schedulesjsonnString);
                ViewData["MobileFoodSchedules"] = mobileFoodSchedules;
            }
        }
    }
}