﻿using System.Collections.Generic;

namespace AirlineSchedule.Repository
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> ReadAll();
        T Read(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
