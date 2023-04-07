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
                new Airline("1#Lufthansa"),
                new Airline("2#KLM"),
                new Airline("3#Wizz Air")
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
                //new Flight("1#1#Budapest#London#5000#3*10"),
                new Flight("1#1#Budapest#Párizs#2000#3*10*0"),
                new Flight("2#1#Budapest#Dublin#6000#4*20*0"),
                new Flight("3#1#Párizs#Reykjavík#6700#5*10*0"),
                new Flight("4#1#Párizs#Lisszabon#3000#1*30*0"),
                new Flight("5#1#Reykjavík#London#4000#2*20*0"),
                new Flight("6#1#Dublin#London#1000#0*40*0"),

                new Flight("7#2#Budapest#Washington#1000#6*40*0"),
                new Flight("8#2#Budapest#Párizs#1000#2*50*0"),
                new Flight("9#2#Washington#Moszkva#1000#9*20*0"),
                new Flight("10#2#Washington#Dublin#1000#6*10*0"),
                new Flight("11#2#Párizs#Dublin#1000#2*15*0"),
                new Flight("12#2#Dublin#London#1000#0*50*0"),
                new Flight("13#2#Dublin#Lisszabon#1000#2*10*0")

           });
            
        }

    }
}