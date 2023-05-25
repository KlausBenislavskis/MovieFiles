using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieFiles.Core.Interfaces;

using MovieFiles.Api.Client.Mappers;

namespace MovieFiles.Api.Client.Services
{
    public class PeopleService : BaseService, IPeopleService
    {
        public PeopleService(string httpUrl, string functionAppKey) : base(httpUrl, functionAppKey){}

        async Task<Core.Models.People.PeopleList?> IPeopleService.GetPopularPeople(int page)
        {
            var response = await _client.PopularPeopleAsync(page,_functionAppKey);
            return ClientToUi.Map(response);
        }

        async Task<Core.Models.People.PeopleList?> IPeopleService.SearchPeople(string query)
        {
            var response = await _client.SearchPeopleAsync(query,_functionAppKey);
            return ClientToUi.Map(response);
        }
    }
}