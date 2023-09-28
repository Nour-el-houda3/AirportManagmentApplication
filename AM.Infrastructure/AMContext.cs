using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=NourelhoudaLandoulsiDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigureationBuilder)
        {
            modelConfigureationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        //tekteb prop w double tabulation(ces methodes permettent de créer des tables)
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes {get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<staff> staff { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
    }

   
}
