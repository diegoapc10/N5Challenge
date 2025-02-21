using Domain.Dtos;
using Domain.Models;
using Elastic.Clients.Elasticsearch;
using Infrastructure.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Handlers
{
    public class RequestPermissionHandler
    {
        private readonly IRequestPermissionCommand _requestPermissionCommand;
        private readonly ElasticsearchClient _client;
        private string _indexName;

        public RequestPermissionHandler(IRequestPermissionCommand requestPermissionCommand, string urlElasticsearch, string indexName)
        {
            _requestPermissionCommand = requestPermissionCommand;
            _client = new ElasticsearchClient(new Uri(urlElasticsearch));
            _indexName = indexName;
        }

        public async Task<PermissionDto> Handle(PermissionDto permission)
        {
            var index = await _client.Indices.GetAsync(_indexName);

            if(!index.IsValidResponse)
                await _client.Indices.CreateAsync(_indexName);

            var newPermissionRequest = await _requestPermissionCommand.Execute(permission);
            var indexResponse = await _client.IndexAsync(newPermissionRequest, x => x.Index(_indexName));

            return newPermissionRequest;
        }
    }
}
