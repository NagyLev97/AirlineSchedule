using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Client.Helper
{
    public class AirlineHelper
    {
        public static int GetAirline(ICollection<Flight> flights, string from, string to)
        {
            var item = flights.Where(t => t.CityFrom.Name == from && t.CityTo.Name == to).OrderBy(t => t.FlightTime).FirstOrDefault();
            return item.AirlineId;
        }
    }
}
