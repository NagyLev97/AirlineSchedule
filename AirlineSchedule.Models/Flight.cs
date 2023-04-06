using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Models
{
    internal class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }

        [Required]
        public City CityFrom { get; set; }

        [Required]
        public City CityTo { get; set; }

        [Required]
        public int Distance { get; set; }

        [Required]
        public TimeSpan FlightTime { get; set; }

        [Required]
        public DateTime StartingTime { get; set; }
    }
}
