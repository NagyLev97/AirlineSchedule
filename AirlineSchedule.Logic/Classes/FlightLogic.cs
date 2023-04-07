using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System.Collections.Generic;

namespace AirlineSchedule.Logic
{
    public class FlightLogic : IFlightLogic
    {
        private readonly IRepository<Flight> _repo;

        public FlightLogic(IRepository<Flight> repo)
        {
            _repo = repo;
        }

        public void Create(Flight item)
        {
            _repo.Create(item);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public Flight Read(int id)
        {
            return _repo.Read(id);
        }

        public ICollection<Flight> ReadAll()
        {
            return _repo.ReadAll();
        }

        public void Update(Flight item)
        {
            _repo.Update(item);
        }
    }
}
