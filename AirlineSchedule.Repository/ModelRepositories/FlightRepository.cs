using AirlineSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Repository
{
    public class FlightRepository : Repository<Flight>, IRepository<Flight>
    {
        public FlightRepository(AirlineDbContext ctx) : base(ctx)
        {
        }

        public override Flight Read(int id)
        {
            return ctx.Flights.FirstOrDefault(t => t.FlightId == id);
        }

        public override void Update(Flight item)
        {
            var old = Read(item.FlightId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
