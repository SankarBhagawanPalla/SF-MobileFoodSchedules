using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileFoodSchedules.Models;
using Permits;
using Schedules;

namespace MobileFoodSchedules.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SAApprovedFoodSchedulesController : ControllerBase
    {

        public MobileFoodPermit[] mobileFoodPermits;
        public IEnumerable<Schedules.MobileFoodSchedule> mobileFoodSchedules { get; set; }
        IList<SAApprovedFoodSchedules> mobileFoodSchedulesApproved = new List<SAApprovedFoodSchedules>();
        public IEnumerable<Permits.MobileFoodPermit> mobileFoodPermitList { get; set; }


        // GET: api/SAApprovedFoodSchedules
        [HttpGet]
        public IList<SAApprovedFoodSchedules> GetSAApprovedFoodSchedules()
        {

            using (var webClient = new WebClient())
            {
                String permitjsonString = webClient.DownloadString("https://data.sfgov.org/resource/rqzj-sfat.json");
                mobileFoodPermits = MobileFoodPermit.FromJson(permitjsonString);
                mobileFoodPermitList = mobileFoodPermits.ToList();


                String schedulesjsonnString = webClient.DownloadString("https://data.sfgov.org/resource/jjew-r69b.json");
                mobileFoodSchedules = MobileFoodSchedule.FromJson(schedulesjsonnString);

                IDictionary<string, MobileFoodPermit> permistApprovedMap = new Dictionary<string, MobileFoodPermit>();
                foreach (Permits.MobileFoodPermit permit in mobileFoodPermitList)
                {
                    if (permit.Status.ToString() == "Approved")
                    {
                        if (!permistApprovedMap.ContainsKey(permit.Applicant.ToString()))
                        {
                            permistApprovedMap.Add(permit.Applicant.ToString(), permit);
                        }
                        
                    }
                }
                foreach (Schedules.MobileFoodSchedule sch in mobileFoodSchedules)
                {
                    if (permistApprovedMap.ContainsKey(sch.Applicant.ToString()))
                    {
                        SAApprovedFoodSchedules schedule = new SAApprovedFoodSchedules();
                        schedule.dayofweekstr = sch.Dayofweekstr.ToString();
                        schedule.starttime = sch.Starttime.ToString();
                        schedule.endtime = sch.Endtime.ToString();
                        schedule.applicant = sch.Applicant.ToString();
                        //schedule.locationdesc = sch.Locationdesc.ToString();
                        schedule.location = sch.Location.ToString();
                        mobileFoodSchedulesApproved.Add(schedule);
                    }
                }
                return mobileFoodSchedulesApproved;
            }



        }

        
    }
}
