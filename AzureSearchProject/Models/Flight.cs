using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchProject.Models
{
    [SerializePropertyNamesAsCamelCase]
    public class Flight
    {
        [Key]
        [IsFilterable]
        public string FlightId { get; set; }

        [IsFilterable, IsSearchable]
        public string From { get; set; }

        [IsFilterable, IsSearchable]
        public string To { get; set; }

        [IsSortable]
        public double Duration { get; set; }

        [IsFilterable, IsSearchable]
        public string Airline { get; set; }

        [IsSortable, IsFilterable, IsSearchable]
        public bool DirectFlight { get; set; }

        [IsSearchable]
        public double Cost { get; set; }

        [IsSearchable, IsFilterable]
        public string Class { get; set; }

        [IsFilterable, IsSearchable]
        public DateTime DepartureTime { get; set; }

        [IsFilterable, IsSearchable]
        public DateTime ArrivalTime { get; set; }

        public Flight()
        {
            // Random Values
            Duration = new Random().Next(6, 25);

            DepartureTime = DateTime.Now.AddHours(2);

            ArrivalTime = DateTime.Now.AddDays(1);

            Cost = new Random().Next(10000, 100000);
        }
    }
}
