using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using FlightSearchProject.Models;
using FlightSearchProject.Options;
using Microsoft.Extensions.Options;

namespace FlightSearchProject.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private string indexName = "flights";

        public IEnumerable<Flight> ReturnFlights()
        {
            var flights = new Flight[] {
                new Flight {
                    FlightId = "1",
                    Airline = "Air France",
                    From = "England",
                    To = "France",
                    Class = "Economy",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 10)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 30)),
                    Cost = new Random().Next(23432, 68644)
                },
                new Flight {
                    FlightId = "2",
                    Airline = "Spanish Airlines",
                    From = "Spain, Madrid, Madrid Barajas International",
                    To = "Hong Kong, Hong Kong, Hong Kong International",
                    Class = "Business Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 10)),
                    Cost = new Random().Next(12346, 45442)
                },
                new Flight {
                    FlightId = "3",
                    Airline = "Virgin Airways",
                    From = "Hong Kong, Hong Kong, Hong Kong International",
                    To = "United Arab Emirates, Dubai, Dubai International",
                    Class = "Economy",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 10)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 50)),
                    Cost = new Random().Next(33453, 607615)
                },
                new Flight {
                    FlightId = "4",
                    Airline = "South African Airways",
                    From = "Malaysia, Kuala Lumpur, Kuala Lumpur International",
                    To = "South Africa, Johannesburg, OR Tambo International",
                    Class = "Premium Economy",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 60)),
                    Cost = new Random().Next(23432, 798722)
                },
                new Flight {
                    FlightId = "5",
                    Airline = "British Airways",
                    From = "Japan, Tokyo, Tokyo International",
                    To = "Spain, Madrid, Madrid Barajas International",
                    Class = "Premium Economy",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 50)),
                    Cost = new Random().Next(63432, 785675)
                },
                new Flight {
                    FlightId = "6",
                    Airline = "Turkish Airlines",
                    From = "United States, Los Angeles, Los Angeles International",
                    To = "England, London, London Heathrow",
                    Class = "First Class",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 70)),
                    Cost = new Random().Next(3543, 98772)
                },
                new Flight {
                    FlightId = "7",
                    Airline = "British Airways",
                    From = "Japan, Tokyo, Tokyo International",
                    To = "England, London, London Heathrow",
                    Class = "Business Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(9000, 10120)
                },
                new Flight {
                    FlightId = "8",
                    Airline = "Ethiopian Airways",
                    From = "South Africa, Johannesburg, OR Tambo International",
                    To = "France, Paris, Charles de Gaulle International",
                    Class = "Premium Economy",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(34367, 89879)
                },
                new Flight {
                    FlightId = "9",
                    Airline = "Etihad Airways",
                    From = "United Arab Emirates, Dubai, Dubai International",
                    To = "Malaysia, Kuala Lumpur, Kuala Lumpur International",
                    Class = "First Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 40)),
                    Cost = new Random().Next(23432, 65753)
                },
                new Flight {
                    FlightId = "10",
                    Airline = "Lufthansa",
                    From = "Germany, Frankfurt, Frankfurt am Main International",
                    To = "France, Paris, Charles de Gaulle International",
                    Class = "Economy",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(32, 40)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(2342, 57565)
                },
                new Flight {
                    FlightId = "11",
                    Airline = "Lufthansa",
                    From = "France, Paris, Charles de Gaulle International",
                    To = "South Africa, Johannesburg, OR Tambo International",
                    Class = "First Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(2, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(3, 25)),
                    Cost = new Random().Next(14000, 20020)
                },
                new Flight {
                    FlightId = "12",
                    Airline = "Spanish Airlines",
                    From = "Spain, Madrid, Madrid Barajas International",
                    To = "Hong Kong, Hong Kong, Hong Kong International",
                    Class = "Business Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(10, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(10, 45)),
                    Cost = new Random().Next(4231, 46546)
                },
                new Flight {
                    FlightId = "13",
                    Airline = "Cathay Pacific",
                    From = "Hong Kong, Hong Kong, Hong Kong International",
                    To = "United Arab Emirates, Dubai, Dubai International",
                    Class = "Economy",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(3243, 7686)
                },
                new Flight {
                    FlightId = "14",
                    Airline = "Qatar Airways",
                    From = "Malaysia, Kuala Lumpur, Kuala Lumpur International",
                    To = "South Africa, Johannesburg, OR Tambo International",
                    Class = "Premium Economy",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(23247, 88797)
                },
                new Flight {
                    FlightId = "15",
                    Airline = "British Airways",
                    From = "Japan, Tokyo, Tokyo International",
                    To = "Spain, Madrid, Madrid Barajas International",
                    Class = "Premium Economy",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(12, 40)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(11, 70)),
                    Cost = new Random().Next(14800, 32323)
                },
                new Flight {
                    FlightId = "16",
                    Airline = "Emirates",
                    From = "United States, Los Angeles, Los Angeles International",
                    To = "England, London, London Heathrow",
                    Class = "First Class",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(21, 100)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(31, 90)),
                    Cost = new Random().Next(1000, 109000)
                },
                new Flight {
                    FlightId = "17",
                    Airline = "British Airways",
                    From = "Japan, Tokyo, Tokyo International",
                    To = "England, London, London Heathrow",
                    Class = "Business Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(12, 30)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(10, 50)),
                    Cost = new Random().Next(2433, 78797)
                },
                new Flight {
                    FlightId = "18",
                    Airline = "Qantas Airways",
                    From = "South Africa, Johannesburg, OR Tambo International",
                    To = "France, Paris, Charles de Gaulle International",
                    Class = "Premium Economy",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(12242, 44564)
                },
                new Flight {
                    FlightId = "19",
                    Airline = "Etihad Airways",
                    From = "United Arab Emirates, Dubai, Dubai International",
                    To = "Germany, Frankfurt, Frankfurt am Main International",
                    Class = "First Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(5454, 76786)
                },
                new Flight {
                    FlightId = "20",
                    Airline = "Aeroflot",
                    From = "Hong Kong, Hong Kong, Hong Kong International",
                    To = "Germany, Frankfurt, Frankfurt am Main International",
                    Class = "Economy",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(10340, 18400)
                },
                new Flight {
                    FlightId = "21",
                    Airline = "Singapore Airlines",
                    From = "England, London, London Heathrow",
                    To = "France, Paris, Charles de Gaulle International",
                    Class = "Economy",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(1000, 90000)
                },
                new Flight {
                    FlightId = "22",
                    Airline = "Qatar Airways",
                    From = "Spain, Madrid, Madrid Barajas International",
                    To = "Hong Kong, Hong Kong, Hong Kong International",
                    Class = "Business Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(1000, 10000)
                },
                new Flight {
                    FlightId = "23",
                    Airline = "Virgin Airways",
                    From = "Hong Kong, Hong Kong, Hong Kong International",
                    To = "United Arab Emirates, Dubai, Dubai International",
                    Class = "Economy",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(2000, 10430)
                },
                new Flight {
                    FlightId = "24",
                    Airline = "South African Airways",
                    From = "Malaysia, Kuala Lumpur, Kuala Lumpur International",
                    To = "South Africa, Johannesburg, OR Tambo International",
                    Class = "Premium Economy",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(1200, 4334)
                },
                new Flight {
                    FlightId = "25",
                    Airline = "Emirates",
                    From = "Japan, Tokyo, Tokyo International",
                    To = "Spain, Madrid, Madrid Barajas International",
                    Class = "Premium Economy",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(4554, 77879)
                },
                new Flight {
                    FlightId = "26",
                    Airline = "Turkish Airlines",
                    From = "United States, Los Angeles, Los Angeles International",
                    To = "England, London, London Heathrow",
                    Class = "First Class",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(3422, 78978)
                },
                new Flight {
                    FlightId = "27",
                    Airline = "Singapore Airlines",
                    From =  "Turkey, Ataturk, Atatürk International",
                    To = "England, London, London Heathrow",
                    Class = "Business Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(1232, 56154)
                },
                new Flight {
                    FlightId = "28",
                    Airline = "EVA Air",
                    From = "France, Paris, Charles de Gaulle International",
                    To = "South Africa, Johannesburg, OR Tambo International",
                    Class = "Premium Economy",
                    DirectFlight = false,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(3232, 65756)
                },
                new Flight {
                    FlightId = "29",
                    Airline = "Emirates",
                    From =  "Turkey, Ataturk, Atatürk International",
                    To = "Germany, Frankfurt, Frankfurt am Main International",
                    Class = "First Class",
                    DirectFlight = true,
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(32432, 99833)
                },
                new Flight {
                    FlightId = "30",
                    Airline = "Virgin Atlantic",
                    From =  "Malaysia, Kuala Lumpur, Kuala Lumpur International",
                    To = "United States, Los Angeles, Los Angeles International",
                    Class = "Economy",
                    DirectFlight = true, 
                    DepartureTime = new DateTime().AddHours(new Random().Next(1, 20)),
                    ArrivalTime = new DateTime().AddDays(new Random().Next(1, 20)),
                    Cost = new Random().Next(13430, 32232)
                }
            };

            return flights;
        }

        public void AddFlightData(ISearchIndexClient indexClient)
        {
            var flights = ReturnFlights();

            //batch
            var batch = IndexBatch.Upload(flights);

            try
            {
                indexClient.Documents.Index(batch);
            }
            catch (Exception)
            {
                //Sometimes indexing will fail due to load
                throw;
            }
        }

        public void CreateFlightsIndex(SearchServiceClient serviceClient)
        {
            var flightsIndex = new Index()
            {
                Name = indexName,
                Fields = FieldBuilder.BuildForType<Flight>()
            };

            serviceClient.Indexes.Create(flightsIndex);
        }

        public SearchIndexClient CreateSearchIndexClient(string apiKey, string serviceName)
        {
            //index name: flights
            SearchIndexClient indexClient = new SearchIndexClient(serviceName, indexName, new SearchCredentials(apiKey));

            return indexClient;
        }

        public SearchServiceClient CreateSearchServiceClient(string apiKey, string serviceName)
        {
            SearchServiceClient serviceClient = new SearchServiceClient(serviceName, new SearchCredentials(apiKey));

            return serviceClient;
        }

        public void DeleteFlightsIndexIfExists(SearchServiceClient serviceClient)
        {
            if (serviceClient.Indexes.Exists(indexName))
            {
                serviceClient.Indexes.Delete(indexName);
            }
        }

        public IEnumerable<SearchResult<Flight>> ReturnSearchResult(ISearchIndexClient indexClient, string from, string to, bool directFlight)
        {
            SearchParameters parameters;
            DocumentSearchResult<Flight> results;

            // Returns the following parameters.
            parameters = new SearchParameters()
            {
                Filter = "to eq " + to + " and from eq " + from + " and directFlight eq " + directFlight,
                Select = new[] { "from", "to", "directFlight", "airline", "cost", "class", "departureTime", "arrivalTime" },
                Top = 1
            };

            results = indexClient.Documents.Search<Flight>("*", parameters);

            return results.Results;
        }
    }
}
