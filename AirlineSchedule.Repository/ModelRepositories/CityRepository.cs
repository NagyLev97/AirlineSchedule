using AirlineSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Repository
{
    public class CityRepository : Repository<City>, IRepository<City>
    {
        public CityRepository(AirlineDbContext ctx) : base(ctx)
        {
        }

        public override City Read(int id)
        {
            return ctx.Cities.FirstOrDefault(t => t.CityId == id);
        }

        public override ICollection<City> ReadAll()
        {
            return ctx.Cities.ToList();
        }

        public override void Update(City item)
        {
            var old = Read(item.CityId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
