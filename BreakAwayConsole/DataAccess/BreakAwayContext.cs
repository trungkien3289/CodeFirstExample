using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BreakAwayContext : DbContext
    {
        public BreakAwayContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
