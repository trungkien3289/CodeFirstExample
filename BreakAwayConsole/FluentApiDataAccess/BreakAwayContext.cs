using FluentApiModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiDataAccess
{
    public class BreakAwayContext : DbContext
    {
        public BreakAwayContext()
            : base("CodeFirstFluentApiConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new DestinationCofiguration());
            modelBuilder.Configurations.Add(new LodgingConfiguration());
            modelBuilder.Configurations.Add(new TripConfiguration());
            modelBuilder.Configurations.Add(new InternetSpecialConfiguration());
            modelBuilder.Configurations.Add(new PersonPhotoConfiguration());
            
            modelBuilder.ComplexType<Address>();
        }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
