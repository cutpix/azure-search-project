﻿using Microsoft.Azure.Search;
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
    }
}
