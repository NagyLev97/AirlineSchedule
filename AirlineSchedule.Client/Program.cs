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
            var repo = new AirlineRepository(ctx);
            var logic = new AirlineLogic(repo);

            var items = logic.ReadAll();
            
        }
    }
}