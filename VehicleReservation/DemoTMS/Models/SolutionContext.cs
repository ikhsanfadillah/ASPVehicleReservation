using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTMS.Models
{
    public class SolutionContext : DbContext
    {
        public SolutionContext(DbContextOptions<SolutionContext> options)
            : base(options)
        { }
        public DbSet<MasterUser> MasterUsers { get; set; }
        public DbSet<MasterVehicle> MasterVehicles{ get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
