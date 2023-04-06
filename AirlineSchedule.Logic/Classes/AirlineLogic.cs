using System;
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

        public IQueryable<Airline> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Airline item)
        {
            this.repo.Update(item);
        }

    }
}