using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Logic
{
    public class FlightLogic : IFlightLogic
    {
        IRepository<Flight> repo;

        public FlightLogic(IRepository<Flight> repo)
        {
            this.repo = repo;
        }

        public void Create(Flight item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Flight Read(int id)
        {
            return this.repo.Read(id);
        }

        public ICollection<Flight> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Flight item)
        {
            this.repo.Update(item);
        }

    }
}
