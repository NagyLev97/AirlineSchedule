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

            Console.WriteLine("A legrövidebb út: ");
            for (int i = 1; i < airlineRepo.ReadAll().Count()+1; i++)
            {
                List<City> cities = airlineLogic.ShortestJourney(airlineRepo.ReadAllFlights(i), cityRepo, budapest, london, ref sumTime);
                Display(cities, london, sumTime, i, airlineRepo);
                
            }

            //--------------------------------------------------

            List<Flight> flights = new List<Flight>();
            ICollection<Airline> airlines = airlineRepo.ReadAll();

            for (int i = 1; i < airlines.Count() + 1; i++)
            {
                foreach (var item in airlineRepo.ReadAllFlights(i))
                {
                    flights.Add(item);
                }
            }

            double allSumTime = 0;

            List<City> citiesWithAllAirlines = airlineLogic.ShortestJourney(flights, cityRepo, budapest, london, ref allSumTime);
            Console.WriteLine("Bármely légitársasággal a legrövidebb út:");
            DisplayWithAllAirlines(citiesWithAllAirlines, london, allSumTime, airlineRepo);
            ;


            //--------------------------------------------------

            Console.ReadKey();

            ;

        }

        static void Display(List<City> cities, City to, double sumTime, int id, AirlineRepository repo)
        {
            Airline airline = repo.Read(id);
            Console.WriteLine($"\t{airline.Name}:");
            int i = cities.Count() - 1;
            
            if (sumTime == double.PositiveInfinity)
            {
                Console.WriteLine("\t\tNincs útvonal");
            }
            else
            {
                while (cities[i] != to)
                {
                    Console.WriteLine("\t\t" + cities[i].Name + " -> " + cities[i - 1].Name + ": " + "x perc");
                    i--;
                }
                Console.WriteLine("\t\t------");
                double hour = Math.Round((sumTime / 60));
                double minute = sumTime % 60;
                Console.WriteLine("\tÖsszesen: " + hour + " óra " + minute + " perc");
            }
            Console.WriteLine();
        }

        static void DisplayWithAllAirlines(List<City> cities, City to, double sumTime, AirlineRepository repo)
        {
            int i = cities.Count() - 1;

            if (sumTime == double.PositiveInfinity)
            {
                Console.WriteLine("\tNincs útvonal");
            }
            while (cities[i] != to)
            {
                Console.WriteLine("\t" + cities[i].Name + " -> " + cities[i - 1].Name + ": " + "x perc");
                i--;
            }
            Console.WriteLine("\t------");
            double hour = Math.Round((sumTime / 60));
            double minute = sumTime % 60;
            Console.WriteLine("\tÖsszesen: " + hour + " óra " + minute + " perc");
            Console.WriteLine();
        }
    }
}