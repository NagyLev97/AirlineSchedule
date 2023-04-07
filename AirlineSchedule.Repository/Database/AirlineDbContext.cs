using AirlineSchedule.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineSchedule.Repository

{
    public class AirlineDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public AirlineDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("airline");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>(flight => flight
                .HasOne(flight => flight.Airline)
                .WithMany(flight => flight.Flights)
                .HasForeignKey(flight => flight.AirlineId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Flight>(flight => flight
                .HasOne(flight => flight.CityFrom)
                .WithMany()
                .HasForeignKey(flight => flight.CityFromId));

            modelBuilder.Entity<Flight>(flight => flight
                .HasOne(flight => flight.CityTo)
                .WithMany()
                .HasForeignKey(flight => flight.CityToId));

            modelBuilder.Entity<Airline>().HasData(new Airline[]
            {
                new Airline(){ Id = 1, Name = "Lufthansa"},
                new Airline(){ Id = 2, Name = "KLM"},
                new Airline(){ Id = 3, Name = "Wizz Air"}
            });

            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City(){ Id = 1, Name = "Budapest", Population = 1756000},
                new City(){ Id = 2, Name = "London", Population = 898200},
                new City(){ Id = 3, Name = "Párizs", Population = 2161000},
                new City(){ Id = 4, Name = "Washington", Population = 712816},
                new City(){ Id = 5, Name = "Koppenhága", Population = 602481},
                new City(){ Id = 6, Name = "Los Angeles", Population = 3849000},
                new City(){ Id = 7, Name = "Dublin", Population = 544107},
                new City(){ Id = 8, Name = "Moszkva", Population = 1198000},
                new City(){ Id = 9, Name = "Reykjavík", Population = 135688},
                new City(){ Id = 10, Name = "Lisszabon", Population = 545923},
                new City(){ Id = 11, Name = "Athén", Population = 664046},
                new City(){ Id = 12, Name = "Torontó", Population = 2731571}
            });

            modelBuilder.Entity<Flight>().HasData(new Flight[]
           {
               new Flight() // Reyk -> London
               {
                   Id = 1,
                   AirlineId = 1,
                   CityFromId = 9,
                   CityToId = 2,
                   Distance = 1890,
                   FlightTime = new System.TimeSpan(2,25,0)
               },

               new Flight() // Reyk -> Dublin
               {
                   Id = 2,
                   AirlineId = 1,
                   CityFromId = 9,
                   CityToId = 7,
                   Distance = 1494,
                   FlightTime = new System.TimeSpan(1,50,0)
               },

               new Flight() // London -> Lisszabon
               {
                   Id = 3,
                   AirlineId = 1,
                   CityFromId = 2,
                   CityToId = 10,
                   Distance = 1585,
                   FlightTime = new System.TimeSpan(1,52,0)
               },

               new Flight() // London -> Koppenhága
               {
                   Id = 4,
                   AirlineId = 1,
                   CityFromId = 2,
                   CityToId = 5,
                   Distance = 955,
                   FlightTime = new System.TimeSpan(1,19,0)
               },

               new Flight() // London -> Budapest
               {
                   Id = 5,
                   AirlineId = 1,
                   CityFromId = 2,
                   CityToId = 1,
                   Distance = 1449,
                   FlightTime = new System.TimeSpan(1,48,0)
               },

               new Flight() // London -> Moszkva
               {
                   Id = 6,
                   AirlineId = 1,
                   CityFromId = 2,
                   CityToId = 8,
                   Distance = 2500,
                   FlightTime = new System.TimeSpan(3,10,0)
               },

               new Flight() // Bp -> Washington
               {
                   Id = 7,
                   AirlineId = 1,
                   CityFromId = 1,
                   CityToId = 4,
                   Distance = 7334,
                   FlightTime = new System.TimeSpan(9,15,0)
               },

               new Flight() // Washington -> LA
               {
                   Id = 8,
                   AirlineId = 1,
                   CityFromId = 4,
                   CityToId = 6,
                   Distance = 3693,
                   FlightTime = new System.TimeSpan(4,30,0)
               },

               new Flight() // Dublin -> Torontó
               {
                   Id = 9,
                   AirlineId = 1,
                   CityFromId = 7,
                   CityToId = 12,
                   Distance = 5250,
                   FlightTime = new System.TimeSpan(6,42,0)
               },

               new Flight() // Dublin -> Budapest
               {
                   Id = 10,
                   AirlineId = 1,
                   CityFromId = 7,
                   CityToId = 1,
                   Distance = 1895,
                   FlightTime = new System.TimeSpan(2,18,0)
               },

               new Flight() // Torontó - LA
               {
                   Id = 11,
                   AirlineId = 1,
                   CityFromId = 12,
                   CityToId = 6,
                   Distance = 3494,
                   FlightTime = new System.TimeSpan(4,12,0)
               },

               new Flight() // Budapest -> Lisszabon
               {
                   Id = 12,
                   AirlineId = 1,
                   CityFromId = 1,
                   CityToId = 10,
                   Distance = 2470,
                   FlightTime = new System.TimeSpan(3,2,0)
               },

               new Flight() // Lisszabon -> Moszkva
               {
                   Id = 13,
                   AirlineId = 1,
                   CityFromId = 10,
                   CityToId = 8,
                   Distance = 3906,
                   FlightTime = new System.TimeSpan(4,55,0)
               },

               new Flight() // Moszkva -> LA
               {
                   Id = 14,
                   AirlineId = 1,
                   CityFromId = 8,
                   CityToId = 6,
                   Distance = 9769,
                   FlightTime = new System.TimeSpan(12,15,0)
               },

               new Flight() // Rejk -> Budapest
               {
                   Id = 15,
                   AirlineId = 2,
                   CityFromId = 9,
                   CityToId = 1,
                   Distance = 3073,
                   FlightTime = new System.TimeSpan(2,47,0)
               },

               new Flight() // Rejk -> Dublin
               {
                   Id = 16,
                   AirlineId = 2,
                   CityFromId = 9,
                   CityToId = 7,
                   Distance = 1494,
                   FlightTime = new System.TimeSpan(1,52,0)
               },

               new Flight() // Rejk -> London
               {
                   Id = 17,
                   AirlineId = 2,
                   CityFromId = 9,
                   CityToId = 2,
                   Distance = 1890,
                   FlightTime = new System.TimeSpan(2,14,0)
               },

               new Flight() // Budapest -> Athén
               {
                   Id = 18,
                   AirlineId = 2,
                   CityFromId = 1,
                   CityToId = 11,
                   Distance = 1125,
                   FlightTime = new System.TimeSpan(1,42,0)
               },

               new Flight() // Budapest -> Koppenhága
               {
                   Id = 19,
                   AirlineId = 2,
                   CityFromId = 1,
                   CityToId = 5,
                   Distance = 1012,
                   FlightTime = new System.TimeSpan(1,21,0)
               },

               new Flight() // Athén -> Koppenhága
               {
                   Id = 20,
                   AirlineId = 2,
                   CityFromId = 11,
                   CityToId = 5,
                   Distance = 2137,
                   FlightTime = new System.TimeSpan(2,46,0)
               },

               new Flight() // Koppenhága -> Párizs
               {
                   Id = 21,
                   AirlineId = 2,
                   CityFromId = 5,
                   CityToId = 3,
                   Distance = 1026,
                   FlightTime = new System.TimeSpan(1,19,0)
               },

               new Flight() // Dublin -> Moszkva
               {
                   Id = 22,
                   AirlineId = 2,
                   CityFromId = 7,
                   CityToId = 8,
                   Distance = 0,
                   FlightTime = new System.TimeSpan(12,15,0)
               },

               new Flight() // Moszkva -> Budapest
               {
                   Id = 23,
                   AirlineId = 2,
                   CityFromId = 8,
                   CityToId = 1,
                   Distance = 2795,
                   FlightTime = new System.TimeSpan(3,28,0)
               },

               new Flight() // Moszkva -> Athén
               {
                   Id = 24,
                   AirlineId = 2,
                   CityFromId = 8,
                   CityToId = 11,
                   Distance = 0,
                   FlightTime = new System.TimeSpan(12,15,0)
               },

               new Flight() // London -> Athén
               {
                   Id = 25,
                   AirlineId = 2,
                   CityFromId = 2,
                   CityToId = 11,
                   Distance = 2231,
                   FlightTime = new System.TimeSpan(1,51,0)
               },

               new Flight() // London -> Lisszabon
               {
                   Id = 26,
                   AirlineId = 2,
                   CityFromId = 2,
                   CityToId = 10,
                   Distance = 1585,
                   FlightTime = new System.TimeSpan(2,0,0)
               },

               new Flight() // London -> Washington
               {
                   Id = 27,
                   AirlineId = 2,
                   CityFromId = 2,
                   CityToId = 4,
                   Distance = 5897,
                   FlightTime = new System.TimeSpan(7,14,0)
               },

               new Flight() // Los Angeles -> Washington
               {
                   Id = 28,
                   AirlineId = 2,
                   CityFromId = 6,
                   CityToId = 4,
                   Distance = 3693,
                   FlightTime = new System.TimeSpan(4,31,0)
               },

               new Flight() // Los Angeles -> Torontó
               {
                   Id = 29,
                   AirlineId = 2,
                   CityFromId = 6,
                   CityToId = 12,
                   Distance = 3494,
                   FlightTime = new System.TimeSpan(4,21,0)
               },

               new Flight() // Reykjavík -> Athén
               {
                   Id = 30,
                   AirlineId = 3,
                   CityFromId = 9,
                   CityToId = 11,
                   Distance = 4164,
                   FlightTime = new System.TimeSpan(5,7,0)
               },

               new Flight() // Reykjavík -> Budapest
               {
                   Id = 31,
                   AirlineId = 3,
                   CityFromId = 9,
                   CityToId = 1,
                   Distance = 3073,
                   FlightTime = new System.TimeSpan(3,48,0)
               },

               new Flight() // Reykjavík -> Dublin
               {
                   Id = 32,
                   AirlineId = 3,
                   CityFromId = 9,
                   CityToId = 7,
                   Distance = 1494,
                   FlightTime = new System.TimeSpan(1,53,0)
               },

               new Flight() // Athén -> Moszkva
               {
                   Id = 33,
                   AirlineId = 3,
                   CityFromId = 11,
                   CityToId = 8,
                   Distance = 2231,
                   FlightTime = new System.TimeSpan(2,49,0)
               },

               new Flight() // Athén -> Toronto
               {
                   Id = 34,
                   AirlineId = 3,
                   CityFromId = 11,
                   CityToId = 12,
                   Distance = 8097,
                   FlightTime = new System.TimeSpan(10,2,0)
               },

               new Flight() // Budapest -> Párizs
               {
                   Id = 35,
                   AirlineId = 3,
                   CityFromId = 1,
                   CityToId = 3,
                   Distance = 1244,
                   FlightTime = new System.TimeSpan(1,38,0)
               },

               new Flight() // Budapest -> Washington
               {
                   Id = 36,
                   AirlineId = 3,
                   CityFromId = 1,
                   CityToId = 4,
                   Distance = 7334,
                   FlightTime = new System.TimeSpan(9,17,0)
               },

               new Flight() // Dublin -> London
               {
                   Id = 37,
                   AirlineId = 3,
                   CityFromId = 7,
                   CityToId = 2,
                   Distance = 463,
                   FlightTime = new System.TimeSpan(0,32,0)
               },

               new Flight() // Dublin -> Budapest
               {
                   Id = 38,
                   AirlineId = 3,
                   CityFromId = 7,
                   CityToId = 1,
                   Distance = 1895,
                   FlightTime = new System.TimeSpan(2,23,0)
               },

               new Flight() // Dublin -> Lisszabon
               {
                   Id = 39,
                   AirlineId = 3,
                   CityFromId = 7,
                   CityToId = 10,
                   Distance = 1894,
                   FlightTime = new System.TimeSpan(2,22,0)
               },

               new Flight() // London -> Athén
               {
                   Id = 40,
                   AirlineId = 3,
                   CityFromId = 2,
                   CityToId = 11,
                   Distance = 2392,
                   FlightTime = new System.TimeSpan(3,59,0)
               },

               new Flight() // Párizs -> London
               {
                   Id = 41,
                   AirlineId = 3,
                   CityFromId = 3,
                   CityToId = 2,
                   Distance = 342,
                   FlightTime = new System.TimeSpan(0,20,0)
               },

               new Flight() // Párizs -> Washington
               {
                   Id = 42,
                   AirlineId = 3,
                   CityFromId = 3,
                   CityToId = 4,
                   Distance = 6164,
                   FlightTime = new System.TimeSpan(7,50,0)
               },

               new Flight() // London -> Los Angeles
               {
                   Id = 43,
                   AirlineId = 3,
                   CityFromId = 2,
                   CityToId = 6,
                   Distance = 8756,
                   FlightTime = new System.TimeSpan(8,12,0)
               },

               new Flight() // Washington -> Torontó
               {
                   Id = 44,
                   AirlineId = 3,
                   CityFromId = 4,
                   CityToId = 12,
                   Distance = 564,
                   FlightTime = new System.TimeSpan(0,40,0)
               },

               new Flight() // Torontó -> Los Angeles
               {
                   Id = 45,
                   AirlineId = 3,
                   CityFromId = 12,
                   CityToId = 6,
                   Distance = 3494,
                   FlightTime = new System.TimeSpan(4,11,0)
               }
           });
        }
    }
}