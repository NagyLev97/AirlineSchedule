using System;
using AirlineSchedule.Logic.DijkstraAlgorithm;
using AirlineSchedule.Models;
using AirlineSchedule.Repository;

namespace AirlineSchedule.Logic
{
    public class AirlineLogic : IAirlineLogic
    {
        IRepository<Airline> repo;

        public AirlineLogic(IRepository<Airline> repo)
        {
            this.repo = repo;
        }

        public void Create(Airline item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Airline Read(int id)
        {
            return this.repo.Read(id);
        }

        public ICollection<Airline> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Airline item)
        {
            this.repo.Update(item);
        }

        public List<City> ShortestJourney(ICollection<Flight> flights, CityRepository cityRepo, City from, City where, ref double sumTime)
        {
            BuildGraph graph = new BuildGraph();

            graph.AddNodes(cityRepo);
            graph.AddEdges(flights, cityRepo);

            List<City> cities = graph.Dijkstra(from, where, ref sumTime);

            return cities;
        }


    }
}