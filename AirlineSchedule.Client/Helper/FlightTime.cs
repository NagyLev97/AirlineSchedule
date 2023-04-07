using AirlineSchedule.Logic;

namespace AirlineSchedule.Client.Helper
{
    public class FlightTime
    {
        public static int[] GetTime(AirlineLogic airlineLogic, int id, string from, string to)
        {
            int[] times = new int[2];
            TimeSpan time = airlineLogic.Read(id).Flights.Where(t => t.CityFrom.Name == from && t.CityTo.Name == to).FirstOrDefault().FlightTime;
            times[0] = time.Hours;
            times[1] = time.Minutes;
            return times;
        }
    }
}
