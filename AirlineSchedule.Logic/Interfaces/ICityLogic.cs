using AirlineSchedule.Models;

namespace AirlineSchedule.Logic
{
    internal interface ICityLogic
    {
        void Create(City item);
        void Delete(int id);
        City Read(int id);
        ICollection<City> ReadAll();
        void Update(City item);
        City SmallestCity();
        City BiggestCity();
    }
}