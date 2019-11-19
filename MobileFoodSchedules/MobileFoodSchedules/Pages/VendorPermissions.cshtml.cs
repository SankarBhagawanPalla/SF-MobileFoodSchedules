using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
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
                String permitjsonString = GetData("https://data.sfgov.org/resource/rqzj-sfat.json");
                JSchema schema= JSchema.Parse(System.IO.File.ReadAllText("MobileFoodSchedule.json"));
                JArray jsonArray= JArray.Parse(permitjsonString);
                IList<string> validationEvents = new List<string>();
                if(jsonArray.IsValid(schema))
                {
                    var mobileFoodPermits = MobileFoodPermit.FromJson(permitjsonString);
                    ViewData["MobileFoodPermits"] = mobileFoodPermits;
                }
                else
                {
                    foreach(string evt in validationEvents)
                    {
                        Console.WriteLine(evt);
                    }
                    ViewData["MobileFoodPermits"] = new List <MobileFoodPermit>();
                }



                String schedulesjsonnString = GetData("https://data.sfgov.org/resource/jjew-r69b.json");
                JSchema schema1 = JSchema.Parse(System.IO.File.ReadAllText("MobileFoodSchedule1.json"));
                JArray jsonArray1 = JArray.Parse(permitjsonString);
                IList<string> validationEvents1 = new List<string>();
                if (jsonArray.IsValid(schema1))
                {
                    var mobileFoodSchedules = MobileFoodSchedule.FromJson(schedulesjsonnString);
                    ViewData["MobileFoodSchedules"] = mobileFoodSchedules;
                }
                else
                {
                    foreach (string evt1 in validationEvents1)
                    {
                        Console.WriteLine(evt1);
                    }
                    ViewData["MobileFoodPermits"] = new List<MobileFoodPermit>();
                }
            }
        }
        
    public string GetData(string endpoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endpoint);
            }
            return downloadedData;
        }

    }
}