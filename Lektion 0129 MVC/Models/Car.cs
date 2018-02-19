using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lektion_0129_MVC.Models
{
    public class Car
    {
        static int nextId = 1;
        public int Id { get; private set; }
        public double MaxSpeed { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }


        public Car()

        {
            Id = nextId++;
        }

    }
}