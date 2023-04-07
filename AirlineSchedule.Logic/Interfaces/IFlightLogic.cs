using AirlineSchedule.Models;

namespace AirlineSchedule.Logic
{
    public interface IFlightLogic
    {
        void Create(Flight item);
        void Delete(int id);
        Flight Read(int id);
        ICollection<Flight> ReadAll();
        void Update(Flight item);
        
    }
}