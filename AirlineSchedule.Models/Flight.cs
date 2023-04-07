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
    }
}
