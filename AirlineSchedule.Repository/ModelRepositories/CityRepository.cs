using AirlineSchedule.Models;

namespace AirlineSchedule.Repository
{
    public class CityRepository : Repository<City>
    {
        public CityRepository(AirlineDbContext ctx) : base(ctx)
        {
        }
    }
}
