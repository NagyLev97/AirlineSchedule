using System;
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
                .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Airline>().HasData(new Airline[]
            {
                new Airline("1#Wizz Air"),
                new Airline("2#Lufthansa"),
                new Airline("3#Ryanair"),
                new Airline("4#British Airways"),
                new Airline("5#Transavia"),
            });

            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City("1#Budapest#1756000"),
                new City("2#London#8982000"),
                new City("3#Párizs#2161000"),
                new City("4#Washington#712816"),
                new City("5#Koppenhága#602481"),
                new City("6#Los Angeles#3849000"),
                new City("7#Dublin#544107"),
                new City("8#Moszkva#1198000"),
                new City("9#Reykjavík#135688"),
                new City("10#Lisszabon#545923"),
                new City("11#New York#8468000"),
            });

            modelBuilder.Entity<Flight>().HasData(new Flight[]
           {
                new Flight("1#1#Budapest#London#5000#2023*5*17#3*10")
           });
            
        }

    }
}