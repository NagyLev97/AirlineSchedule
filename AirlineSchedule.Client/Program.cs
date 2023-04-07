using AirlineSchedule.Logic;
using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System;

namespace AirlineSchedule.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new AirlineDbContext();

            var repo = new CityRepository(ctx);

            var cityLogic = new CityLogic(repo);

            var small = cityLogic.SmallestCity();

            var big = cityLogic.BiggestCity();

            ;

        }
    }
}