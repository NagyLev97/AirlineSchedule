using AirlineSchedule.Models;

namespace AirlineSchedule.Repository
{
    public class AirlineRepository : Repository<Airline>
    {
        public AirlineRepository(AirlineDbContext ctx) : base(ctx)
        {
        }
    }
}
