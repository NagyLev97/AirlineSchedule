namespace AirlineSchedule.Models
{
    public class City : BaseModel
    {

        
        public string Name { get; set; }

        
        public int Population { get; set; }

        public City()
        {
            
        }

        public City(string line)
        {
            string[] split = line.Split('#');
            Id = int.Parse(split[0]);
            Name = split[1];
            Population = int.Parse(split[2]);
        }
    }
}
