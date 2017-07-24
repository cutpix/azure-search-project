using FlightSearchProject.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchProject.Repositories
{
    public interface ISearchRepository
    {
        SearchServiceClient CreateSearchServiceClient(string apiKey, string serviceName);

        IEnumerable<Flight> ReturnFlights();

        void CreateFlightsIndex(SearchServiceClient serviceClient);

        void DeleteFlightsIndexIfExists(SearchServiceClient serviceClient);

        SearchIndexClient CreateSearchIndexClient(string apiKey, string serviceName);

        void AddFlightData(ISearchIndexClient indexClient);

        IEnumerable<SearchResult<Flight>> ReturnSearchResult(ISearchIndexClient indexClient, string[] values);

    }
}
