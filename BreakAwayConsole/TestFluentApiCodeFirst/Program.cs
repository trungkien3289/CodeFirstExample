using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApiModel;
using FluentApiDataAccess;
using System.Data.Entity;

namespace TestFluentApiCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BreakAwayContext>());
            InsertDestination();
            InsertTrip();
            Console.ReadLine();
        }

        private static void InsertDestination()
        {
            var destination = new Destination
            {
                Country = "Indonesia",
                Description = "EcoTourism at its best in exquisite Bali",
                Name = "Bali"
            };
            using (var context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);
                context.SaveChanges();
            }
        }

        private static void InsertTrip()
        {
            var trip = new Trip
            {
                CostUSD = 800,
                StartDate = new DateTime(2011, 9, 1),
                EndDate = new DateTime(2011, 9, 14)
            };

            using (var context = new BreakAwayContext())
            {
                context.Trips.Add(trip);
                context.SaveChanges();
            }
        }

        private static void DeleteDestinationInMemoryAndDbCascade()
        {
            int destinationId;
            using (var context = new BreakAwayContext())
            {
                var destination = new Destination
                {
                    Name = "Sample Destination",
                    Lodgings = new List<Lodging>
                    {
                    new Lodging { Name = "Lodging One" },
                    new Lodging { Name = "Lodging Two" }
                    }
                };
                context.Destinations.Add(destination);
                context.SaveChanges();
                destinationId = destination.DestinationId;
            }
            using (var context = new BreakAwayContext())
            {
                var destination = context.Destinations
                .Include("Lodgings")
                .Single(d => d.DestinationId == destinationId);
                var aLodging = destination.Lodgings.FirstOrDefault();
                context.Destinations.Remove(destination);
                Console.WriteLine("State of one Lodging: {0}",
                context.Entry(aLodging).State.ToString());
                context.SaveChanges();
            }
        }
    }
}
