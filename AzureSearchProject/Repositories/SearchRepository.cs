using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using FlightSearchProject.Models;

namespace FlightSearchProject.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private string indexName = "flights";

        private void AddFlightData(ISearchIndexClient indexClient)
        {
            var flights = new Flight[5];

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

        public SearchIndexClient CreateSearchIndexClient()
        {
            string serviceName = "";
            string apiKey = "";

            //index name: flights
            SearchIndexClient indexClient = new SearchIndexClient(serviceName, indexName, new SearchCredentials(apiKey));

            return indexClient;
        }

        public SearchServiceClient CreateSearchServiceClient()
        {
            string serviceName = "";
            string apiKey = "";

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
