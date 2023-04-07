using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System.Collections.Generic;

namespace AirlineSchedule.Logic
{
    public class AirlineLogic : IAirlineLogic
    {
        private readonly IRepository<Airline> _repo;

        public AirlineLogic(IRepository<Airline> repo)
        {
            this._repo = repo;
        }

        public void Create(Airline item)
        {
            this._repo.Create(item);
        }

        public void Delete(int id)
        {
            this._repo.Delete(id);
        }

        public Airline Read(int id)
        {
            return this._repo.Read(id);
        }

        public ICollection<Airline> ReadAll()
        {
            return this._repo.ReadAll();
        }

        public void Update(Airline item)
        {
            this._repo.Update(item);
        }

        public List<City> ShortestJourney(ICollection<Flight> flights, 
            CityLogic cityLogic,
            City from, 
            City where,
            ref double sumTime)
        {
            BuildGraph graph = new BuildGraph();

            graph.AddNodes(cityLogic);
            graph.AddEdges(flights);

            List<City> cities = graph.Dijkstra(from, where, ref sumTime);

            return cities;
        }
    }
}