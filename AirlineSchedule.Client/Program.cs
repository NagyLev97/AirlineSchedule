using AirlineSchedule.Models;
using AirlineSchedule.Repository;
using System;

namespace AirlineSchedule.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("dd");

            AirlineDbContext ctx = new AirlineDbContext();

            var items = ctx.Airlines.ToArray();

            ;
        }
    }
}