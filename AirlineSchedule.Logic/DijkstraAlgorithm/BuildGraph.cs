using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Logic.DijkstraAlgorithm
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

        public void AddEdges(FlightRepository flightRepo, CityRepository cityRepo)
        {
            foreach (Flight flight in flightRepo.ReadAll())
            {
                City from = cityRepo.ReadAll().Where(c => c.Name == flight.CityFrom).FirstOrDefault();
                City to = cityRepo.ReadAll().Where(c => c.Name == flight.CityTo).FirstOrDefault();

                cityGraph.NewEdge(from, to, 5);
            }
        }
        
        public List<City> Dijkstra(City start, City goal, ref double weightSum)
        {
            return cityGraph.Dijkstra(start, goal, ref weightSum);
        }
    }
}
