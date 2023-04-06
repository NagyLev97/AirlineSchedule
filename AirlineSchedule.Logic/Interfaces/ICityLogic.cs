﻿using AirlineSchedule.Models;

namespace AirlineSchedule.Logic
{
    internal interface ICityLogic
    {
        void Create(City item);
        void Delete(int id);
        City Read(int id);
        IQueryable<City> ReadAll();
        void Update(City item);
    }
}