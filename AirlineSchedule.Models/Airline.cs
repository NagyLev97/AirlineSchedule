using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineSchedule.Models
{
    public class Airline : BaseModel
    {
        public string Name { get; set; } 

        public virtual ICollection<Flight> Flights { get; set; }
    }
}