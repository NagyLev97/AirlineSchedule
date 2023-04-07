using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Client.Helper
{
    public class FlightTime
    {
        public static int[] GetTime(AirlineRepository airlineRepo, int id, string from, string to)
        {
            int[] times = new int[2];
            TimeSpan time = airlineRepo.Read(id).Flights.Where(t => t.CityFrom.Name == from && t.CityTo.Name == to).FirstOrDefault().FlightTime;
            times[0] = time.Hours;
            times[1] = time.Minutes;
            return times;
        }
    }
}
