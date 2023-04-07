using AirlineSchedule.Logic.DijkstraAlgorithm;
using AirlineSchedule.Models;
using System;
using System.Collections.Generic;

namespace AirlineSchedule.Logic
{
    public class BuildGraph
    {
        private readonly Graph<City> _cityGraph = new GraphNeighbourList<City>();

        public void AddNodes(CityLogic cityLogic)
        {
            foreach (City city in cityLogic.ReadAll())
            {
                _cityGraph.NewNood(city);
            }
        }

        public void AddEdges(ICollection<Flight> flights)
        {
            foreach (Flight flight in flights)
            {
                _cityGraph.NewEdge(flight.CityFrom, flight.CityTo, TimeToIntWithWaiting(flight.FlightTime));
            }
        }

        public List<City> Dijkstra(City start, City goal, ref double weightSum)
        {
            return _cityGraph.Dijkstra(start, goal, ref weightSum);
        }

        private static int TimeToIntWithWaiting(TimeSpan time)
        {
            int flightTime = time.Hours * 60 + time.Minutes + time.Seconds;
            int WaitingTime = 60 - (flightTime % 60);
            return flightTime + WaitingTime;
        }
    }
}
