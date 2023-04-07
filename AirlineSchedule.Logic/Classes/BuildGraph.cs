﻿using AirlineSchedule.Logic.Classes;
using AirlineSchedule.Logic.DijkstraAlgorithm;
using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Logic
{
    public class BuildGraph
    {
        Graph<City> cityGraph;
        public BuildGraph()
        {
            cityGraph = new GraphNeighbourList<City>();
        }

        public void AddNodes(CityRepository repo)
        {
            foreach (City city in repo.ReadAll())
            {
                cityGraph.NewNood(city);
            }
        }

        public void AddEdges(ICollection<Flight> flights, CityRepository cityRepo)
        {
            foreach (Flight flight in flights)
            {
                cityGraph.NewEdge(flight.CityFrom, flight.CityTo, TimeToIntWithWaiting(flight.FlightTime));
            }
        }

        public List<City> Dijkstra(City start, City goal, ref double weightSum)
        {
            return cityGraph.Dijkstra(start, goal, ref weightSum);
        }



        public int TimeToIntWithWaiting(TimeSpan time)
        {
            int flightTime = time.Hours * 60 + time.Minutes + time.Seconds;
            int WaitingTime = 60 - (flightTime % 60);
            return flightTime + WaitingTime;
        }

        public int TimeToInt(TimeSpan time)
        {
            int flightTime = time.Hours * 60 + time.Minutes + time.Seconds;
            return flightTime;
        }
    }
}