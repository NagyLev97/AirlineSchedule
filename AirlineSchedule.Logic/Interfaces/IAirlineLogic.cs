using AirlineSchedule.Models;

namespace AirlineSchedule.Logic
{
    public interface IAirlineLogic
    {
        void Create(Airline item);
        void Delete(int id);
        Airline Read(int id);
        IQueryable<Airline> ReadAll();
        void Update(Airline item);
    }
}