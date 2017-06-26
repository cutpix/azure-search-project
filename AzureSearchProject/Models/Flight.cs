﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchProject.Models
{
    public class Flight
    {
        public int FlightId { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Duration { get; set; }

        public string Airline { get; set; }

        public bool DirectFlight { get; set; }

        public string Cost { get; set; }

        public FlightClass Class { get; set; }
    }

    public enum FlightClass
    {
        Economy, Premium, First, Business
    }
}
