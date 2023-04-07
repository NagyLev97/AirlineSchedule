using AirlineSchedule.Logic;
using AirlineSchedule.Logic.DijkstraAlgorithm;
using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System;

namespace AirlineSchedule.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var ctx = new AirlineDbContext();

            var cityRepo = new CityRepository(ctx);
            var flightRepo = new FlightRepository(ctx);
            var airlineRepo = new AirlineRepository(ctx);

            var cityLogic = new CityLogic(cityRepo);
            var airlineLogic = new AirlineLogic(airlineRepo);

            //--------------------------------------------------

            var small = cityLogic.SmallestCity();
            Console.WriteLine($"Legkisebb város: {small.Name}, {small.Population} lakos");

            var big = cityLogic.BiggestCity();
            Console.WriteLine($"Legnagyobb város: {big.Name}, {big.Population} lakos");

            Console.WriteLine();

            //--------------------------------------------------

            double sumTime = 0;

            City budapest = cityRepo.Read(1);
            City london = cityRepo.Read(2);

            
            for (int i = 1; i < airlineRepo.ReadAll().Count(); i++)
            {
                List<City> cities = airlineLogic.ShortestJourney(airlineRepo.ReadAllFlights(i), cityRepo, budapest, london, ref sumTime);
                Display(cities, london, sumTime, i, airlineRepo);
            }

            //--------------------------------------------------

            Console.ReadKey();

            ;

        }

        static void Display(List<City> cities, City to, double sumTime, int id, AirlineRepository repo)
        {
            Airline airline = repo.Read(id);
            Console.WriteLine(airline.Name + ":");
            Console.WriteLine("A legrövidebb út: ");
            int i = cities.Count() - 1;


            while (cities[i] != to)
            {
                Console.WriteLine(cities[i].Name + " -> " + cities[i - 1].Name + ": " + "x perc");
                i--;
            }
            Console.WriteLine("------");
            Console.WriteLine("Összesen: " + sumTime + " perc");
            Console.WriteLine();
        }
    }
}