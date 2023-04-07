using AirlineSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Repository
{
    public class AirlineRepository : Repository<Airline>, IRepository<Airline>
    {
        public AirlineRepository(AirlineDbContext ctx) : base(ctx)
        {
        }

        public override Airline Read(int id)
        {
            return ctx.Airlines.FirstOrDefault(t => t.AirlineId == id);
        }

        public ICollection<Flight> ReadAllFlights(int id)
        {
            Airline airline = Read(id);
            return airline.Flights;
        }

        public override ICollection<Airline> ReadAll()
        {
            return ctx.Airlines.ToList();
        }

        public override void Update(Airline item)
        {
            var old = Read(item.AirlineId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
