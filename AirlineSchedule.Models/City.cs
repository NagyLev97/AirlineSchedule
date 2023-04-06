using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        
        public string Name { get; set; }

        
        public int Population { get; set; }

        public City()
        {
            
        }

        public City(string line)
        {
            string[] split = line.Split('#');
            CityId = int.Parse(split[0]);
            Name = split[1];
            Population = int.Parse(split[2]);
        }
    }
}
