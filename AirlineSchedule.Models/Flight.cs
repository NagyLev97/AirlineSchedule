using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineSchedule.Models
{
    public class Flight : BaseModel
    {
        public int CityFromId { get; set; }
        public virtual City CityFrom { get; set; }
        public int CityToId { get; set; }
        public virtual City CityTo { get; set; }
        public int Distance { get; set; }
        public TimeSpan FlightTime { get; set; }


        public int AirlineId { get; set; }

        public virtual Airline Airline { get; set; }

        public Flight()
        {
            
        }

        public Flight(string line)
        {
            string[] split = line.Split('#');
            Id = int.Parse(split[0]);
            AirlineId = int.Parse(split[1]);
            CityFromId = int.Parse(split[2]);
            CityToId = int.Parse(split[3]);
            Distance = int.Parse(split[4]);
            //StartingTime = DateTime.Parse(split[5].Replace('*', '.'));
            FlightTime = TimeSpan.Parse(split[5].Replace('*', ':'));
        }
    }
}
