using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineSchedule.Models
{
    public class Airline : BaseModel
    {
        
        public string Name { get; set; } 

        public virtual ICollection<Flight> Flights { get; set; }

        public Airline()
        {
            
        }

        public Airline(string line)
        {
            string[] split = line.Split('#');
            Id = int.Parse(split[0]);
            Name = split[1];
        }
    }
}