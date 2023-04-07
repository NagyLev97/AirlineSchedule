using AirlineSchedule.Models;

namespace AirlineSchedule.Repository
{
    public class FlightRepository : Repository<Flight>, IRepository<Flight>
    {
        public FlightRepository(AirlineDbContext ctx) : base(ctx)
        {
        }
    }
}
