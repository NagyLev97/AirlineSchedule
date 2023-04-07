using AirlineSchedule.Models;
using System.Collections.Generic;
using System.Linq;

namespace AirlineSchedule.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected AirlineDbContext ctx;

        public Repository(AirlineDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public ICollection<T> ReadAll()
        {
            return ctx.Set<T>().ToList();
        }

        public T Read(int id)
        {
            return ctx.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public void Update(T item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
