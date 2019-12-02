using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MobileFoodSchedules.Models
{
    public class MobileFoodSchedulesContext : DbContext
    {
        public MobileFoodSchedulesContext (DbContextOptions<MobileFoodSchedulesContext> options)
            : base(options)
        {
        }

        public DbSet<MobileFoodSchedules.Models.SAApprovedFoodSchedules> SAApprovedFoodSchedules { get; set; }
    }
}
