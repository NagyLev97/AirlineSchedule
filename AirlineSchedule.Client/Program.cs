using AirlineSchedule.Client.Helper;
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
                sumTime = 0;
                
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
            DisplayWithAllAirlines(citiesWithAllAirlines, london, allSumTime, airlineRepo, flights);
            ;


            //--------------------------------------------------

            Console.ReadKey();


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
                int[] times = new int[2];
                while (cities[i] != to)
                {
                    times = FlightTime.GetTime(repo, id, cities[i].Name, cities[i - 1].Name);  
                    Console.WriteLine("\t\t" + cities[i].Name + " -> " + cities[i - 1].Name + ": " + times[0] + " óra " + times[1] + " perc");
                    i--;
                }
                Console.WriteLine("\t\t------");

                sumTime = sumTime - (60 - times[1]);
                double hour = Math.Round((sumTime / 60));
                double minute = sumTime % 60;
                Console.WriteLine("\tÖsszesen: " + hour + " óra " + minute + " perc");
            }
            Console.WriteLine();
        }

        static void DisplayWithAllAirlines(List<City> cities, City to, double sumTime, AirlineRepository repo, List<Flight> flights)
        {
            int i = cities.Count() - 1;

            if (sumTime == double.PositiveInfinity)
            {
                Console.WriteLine("\tNincs útvonal");
            }
            int[] times = new int[2];
            while (cities[i] != to)
            {
                int id = AirlineHelper.GetAirline(flights, cities[i].Name, cities[i - 1].Name);
                times = FlightTime.GetTime(repo, id, cities[i].Name, cities[i - 1].Name);
                Console.WriteLine("\t\t" + repo.Read(id).Name + ": " + cities[i].Name + " -> " + cities[i - 1].Name + ": " + times[0] + " óra " + times[1] + " perc");
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