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

        
        public string CityFrom { get; set; }

        
        public string CityTo { get; set; }

        
        public int Distance { get; set; }

        
        public TimeSpan FlightTime { get; set; }

       
        public DateTime StartingTime { get; set; }

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
            CityFrom = split[2];
            CityTo = split[3];
            Distance = int.Parse(split[4]);
            StartingTime = DateTime.Parse(split[5].Replace('*', '.'));
            FlightTime = TimeSpan.Parse(split[6].Replace('*', ':'));
        }
    }
}
