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

        public double? Duration { get; set; }

        public string Airline { get; set; }

        [IsFilterable, IsFacetable]
        public bool? DirectFlight { get; set; }

        [IsFilterable]
        public double? Cost { get; set; }

        public string Class { get; set; }

        public DateTime? DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }
    }
}
