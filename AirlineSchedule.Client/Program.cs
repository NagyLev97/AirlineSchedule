using AirlineSchedule.Client.Helper;
using AirlineSchedule.Logic;
using AirlineSchedule.Models;
using AirlineSchedule.Repository;

namespace AirlineSchedule.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var ctx = new AirlineDbContext();

            var cityLogic = new CityLogic(new CityRepository(ctx));
            var airlineLogic = new AirlineLogic(new AirlineRepository(ctx));
            var flightLogic = new FlightLogic(new FlightRepository(ctx));


            //--------------------------------------------------

            var flights = flightLogic.ReadAll().ToList();

            //--------------------------------------------------

            var small = cityLogic.SmallestCity();
            Console.WriteLine($"Legkisebb város: {small.Name}, {small.Population} lakos");

            var big = cityLogic.BiggestCity();
            Console.WriteLine($"Legnagyobb város: {big.Name}, {big.Population} lakos");

            Console.WriteLine();

            //--------------------------------------------------

            double sumTime = 0;

            Console.WriteLine("A legrövidebb út: ");
            for (int i = 1; i < airlineLogic.ReadAll().Count() + 1; i++) 
            {
                List<City> cities = airlineLogic.ShortestJourney(airlineLogic.Read(i).Flights, cityLogic, small, big, ref sumTime);
                Display(cities, big, sumTime, i, airlineLogic);
                sumTime = 0;
                
            }

            //--------------------------------------------------

            double allSumTime = 0;

            List<City> citiesWithAllAirlines = airlineLogic.ShortestJourney(flights, cityLogic, small, big, ref allSumTime);
            Console.WriteLine("Bármely légitársasággal a legrövidebb út:");
            DisplayWithAllAirlines(citiesWithAllAirlines, big, allSumTime, airlineLogic, flights);

            //--------------------------------------------------

            Console.ReadKey();
        }

        static void Display(List<City> cities, City to, double sumTime, int id, AirlineLogic airlineLogic)
        {
            Airline airline = airlineLogic.Read(id);
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
                    times = FlightTime.GetTime(airlineLogic, id, cities[i].Name, cities[i - 1].Name);  
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

        static void DisplayWithAllAirlines(List<City> cities, City to, double sumTime, AirlineLogic airlineLogic, List<Flight> flights)
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
                times = FlightTime.GetTime(airlineLogic, id, cities[i].Name, cities[i - 1].Name);
                Console.WriteLine("\t\t" + airlineLogic.Read(id).Name + ": " + cities[i].Name + " -> " + cities[i - 1].Name + ": " + times[0] + " óra " + times[1] + " perc");
                i--;
            }

            Console.WriteLine("\t------");

            sumTime = sumTime - (60 - times[1]);
            double hour = Math.Round((sumTime / 60));
            double minute = sumTime % 60;

            Console.WriteLine("\tÖsszesen: " + hour + " óra " + minute + " perc");
            Console.WriteLine();
        }
    }
}