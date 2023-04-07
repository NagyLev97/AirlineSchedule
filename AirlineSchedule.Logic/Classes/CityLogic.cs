using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineSchedule.Models;
using AirlineSchedule.Repository;

namespace AirlineSchedule.Logic
{
    public class CityLogic : ICityLogic
    {
        IRepository<City> repo;

        public CityLogic(IRepository<City> repo)
        {
            this.repo = repo;
        }

        public void Create(City item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public City Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<City> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(City item)
        {
            this.repo.Update(item);
        }

        public City SmallestCity()
        {
            return this.repo.ReadAll().OrderBy(t => t.Population).FirstOrDefault();
        }

        public City BiggestCity()
        {
            return this.repo.ReadAll().OrderByDescending(t => t.Population).FirstOrDefault();
        }
    }
}
