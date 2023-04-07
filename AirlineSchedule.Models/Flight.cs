using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }

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
            FlightId = int.Parse(split[0]);
            AirlineId = int.Parse(split[1]);
            CityFromId = int.Parse(split[2]);
            CityToId = int.Parse(split[3]);
            Distance = int.Parse(split[4]);
            //StartingTime = DateTime.Parse(split[5].Replace('*', '.'));
            FlightTime = TimeSpan.Parse(split[5].Replace('*', ':'));
        }
    }
}
