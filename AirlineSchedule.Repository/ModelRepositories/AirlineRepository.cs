using AirlineSchedule.Models;

namespace AirlineSchedule.Repository
{
    public class AirlineRepository : Repository<Airline>, IRepository<Airline>
    {
        public AirlineRepository(AirlineDbContext ctx) : base(ctx)
        {
        }
    }
}
