﻿using Microsoft.Azure.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchProject.Repositories
{
    public interface ISearchRepository
    {
        SearchServiceClient CreateSearchServiceClient();

        void CreateFlightsIndex(SearchServiceClient serviceClient);

        void DeleteFlightsIndexIfExists(SearchServiceClient serviceClient);

        SearchIndexClient CreateSearchIndexClient();
    }
}