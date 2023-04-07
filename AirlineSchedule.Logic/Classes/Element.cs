using AirlineSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSchedule.Logic.Classes
{
    public class Element
    {
        public string CityName { get; set; }

        public TimeSpan Duration { get; set; }
        public string AirlineName { get; set; }

        public Element()
        {
            
        }
    }
}
