using Domain.Dtos;
using Elastic.Clients.Elasticsearch;
using Infrastructure.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Handlers
{
    public class GetPermissionsHandler
    {
        private readonly IGetPermissionsQuery _query;
        private readonly ElasticsearchClient _client;
        private string _indexName;

        public GetPermissionsHandler(IGetPermissionsQuery query, string urlElasticsearch, string indexName)
        {
            _query = query;
            _client = new ElasticsearchClient(new Uri(urlElasticsearch));
            _indexName = indexName;
        }

        public async Task<IEnumerable<PermissionDto>> Handle()
        {
            var index = await _client.Indices.GetAsync(_indexName);

            if (!index.IsValidResponse)
                await _client.Indices.CreateAsync(_indexName);

            var response = await _client.SearchAsync<PermissionDto>(p => p.Index(_indexName));
            var listaElasticSearch = response.Hits?.Select(hint => hint.Source).ToList();

            if (listaElasticSearch != null && !listaElasticSearch.Any())
                return listaElasticSearch;

            var listFromSql = await _query.Execute();

            return listFromSql;
        }
    }
}
