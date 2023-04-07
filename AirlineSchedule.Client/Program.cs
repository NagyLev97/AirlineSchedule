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

            var cityLogic = new CityLogic(cityRepo);

            var small = cityLogic.SmallestCity();

            var big = cityLogic.BiggestCity();

            BuildGraph graph = new BuildGraph();

            graph.AddNodes(cityRepo);
            graph.AddEdges(flightRepo, cityRepo);

            double km = 0;

            City budapest = cityRepo.Read(1);
            City london = cityRepo.Read(2);
            List<City> cities = graph.Dijkstra(budapest, london, ref km);

            ;

        }

    }
}