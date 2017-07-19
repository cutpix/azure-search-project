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

        [IsSortable, IsFilterable, IsFacetable]
        public double? Duration { get; set; }

        [IsFilterable, IsSearchable]
        public string Airline { get; set; }

        [IsFilterable, IsFacetable]
        public bool? DirectFlight { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public double? Cost { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        public string Class { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public DateTime? DepartureTime { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public DateTime? ArrivalTime { get; set; }

        public Flight()
        {
            // Random Values
            Duration = new Random().Next(6, 25);

            DepartureTime = new DateTime().AddHours(new Random().Next(1, 20));

            ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20));

            Cost = new Random().Next(10000, 100000);
        }
    }
}
