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

        private void AddFlightData(ISearchIndexClient indexClient)
        {
            var flights = new Flight[] {
                new Flight { FlightId = 1, Airline = "Air France", From = "", To = "", Class = FlightClass.Economy, DirectFlight = false  },
                new Flight { FlightId = 2, Airline = "US Airline", From = "", To = "", Class = FlightClass.Business, DirectFlight = true  },
                new Flight { FlightId = 3, Airline = "Virgin Airways", From = "", To = "", Class = FlightClass.Economy, DirectFlight = true  },
                new Flight { FlightId = 4, Airline = "South African Airways", From = "", To = "", Class = FlightClass.Premium, DirectFlight = true  },
                new Flight { FlightId = 5, Airline = "British Airways", From = "", To = "", Class = FlightClass.Premium, DirectFlight = false  },
                new Flight { FlightId = 6, Airline = "Turkish Airlines", From = "", To = "", Class = FlightClass.First, DirectFlight = false  },
                new Flight { FlightId = 7, Airline = "British Airways", From = "", To = "", Class = FlightClass.Business, DirectFlight = true  },
                new Flight { FlightId = 8, Airline = "Ethiopian Airways", From = "", To = "", Class = FlightClass.Premium, DirectFlight = false  },
                new Flight { FlightId = 9, Airline = "Etihad Airways", From = "", To = "", Class = FlightClass.First, DirectFlight = true  },
            };

            //batch
            var batch = IndexBatch.Upload(flights);

            try
            {
                indexClient.Documents.Index(batch);
            }
            catch (Exception exc)
            {
                //Sometimes indexing will fail due to load
                throw exc;
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
    }
}
