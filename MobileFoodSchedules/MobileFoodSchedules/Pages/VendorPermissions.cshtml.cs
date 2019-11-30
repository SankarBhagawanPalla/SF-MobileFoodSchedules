using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Permits;
using Schedules;

namespace MobileFoodSchedules.Pages
{
    public class VendorPermissionsModel : PageModel
    {
        public bool vendorSearch { get; set; }
        [BindProperty]
        public string Search { get; set; }
        public QuickType.MobileFoodPermit[] mobileFoodPermits;
        public QuickType.MobileFoodPermit[] mobileFoodPermitsSearch;
        public IEnumerable<QuickTypee.MobileFoodSchedule> mobileFoodSchedules { get; set; }

        public VendorPermissionsModel()
        {
            using (var webClient = new WebClient())
            {
                

                String permitjsonString = webClient.DownloadString("https://data.sfgov.org/resource/rqzj-sfat.json");
                mobileFoodPermits = MobileFoodPermit.FromJson(permitjsonString);
                

                
                String schedulesjsonnString = webClient.DownloadString("https://data.sfgov.org/resource/jjew-r69b.json");
                mobileFoodSchedules = MobileFoodSchedule.FromJson(schedulesjsonnString);
                
            }
        }
        public void OnGet()
        {
            HashSet<string> vendorNames = new HashSet<string>();

            vendorSearch = false;
            foreach (QuickType.MobileFoodPermit permit in mobileFoodPermits)
            {
                vendorNames.Add(permit.Applicant);
            }
            ViewData["VendorNames"] = vendorNames;
            ViewData["MobileFoodPermits"] = mobileFoodPermits;
            ViewData["MobileFoodSchedules"] = mobileFoodSchedules;

        }

        public void OnPost ()
        {
            if (string.IsNullOrWhiteSpace(Search))
            {
                return;
            }
            HashSet<string> vendorNames = new HashSet<string>();
            foreach (QuickType.MobileFoodPermit permit in mobileFoodPermits)
            {
                vendorNames.Add(permit.Applicant);
            }
            ViewData["VendorNames"] = vendorNames;
            ViewData["MobileFoodPermits"] = mobileFoodPermits;
            ViewData["MobileFoodSchedules"] = mobileFoodSchedules;

            mobileFoodPermitsSearch = mobileFoodPermits.Where(x => x.Applicant.Contains(Search)).ToArray();
            vendorSearch = true;
            
        }
    }
}