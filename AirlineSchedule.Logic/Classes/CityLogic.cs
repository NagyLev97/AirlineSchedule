using System.Collections.Generic;
using System.Linq;
using AirlineSchedule.Models;
using AirlineSchedule.Repository;

namespace AirlineSchedule.Logic
{
    public class CityLogic : ICityLogic
    {
        private readonly IRepository<City> _repo;

        public CityLogic(IRepository<City> repo)
        {
            _repo = repo;
        }

        public void Create(City item)
        {
            _repo.Create(item);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public City Read(int id)
        {
            return _repo.Read(id);
        }

        public ICollection<City> ReadAll()
        {
            return _repo.ReadAll();
        }

        public void Update(City item)
        {
            _repo.Update(item);
        }

        public City SmallestCity()
        {
            return _repo.ReadAll().OrderBy(t => t.Population).FirstOrDefault();
        }

        public City BiggestCity()
        {
            return _repo.ReadAll().OrderByDescending(t => t.Population).FirstOrDefault();
        }
    }
}
