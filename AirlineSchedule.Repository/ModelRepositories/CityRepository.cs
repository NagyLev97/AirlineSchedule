using AirlineSchedule.Models;

namespace AirlineSchedule.Repository
{
    public class CityRepository : Repository<City>, IRepository<City>
    {
        public CityRepository(AirlineDbContext ctx) : base(ctx)
        {
        }
    }
}
