using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileFoodSchedules.Models
{
    public class SAApprovedFoodSchedules
    {
        public string dayofweekstr { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string applicant { get; set; }
        public string location { get; set; }
    }
}
