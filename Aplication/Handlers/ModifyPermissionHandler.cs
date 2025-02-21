using Domain.Dtos;
using Elastic.Clients.Elasticsearch;
using Infrastructure.Implementation.Commands;
using Infrastructure.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Handlers
{
    public class ModifyPermissionHandler
    {
        private readonly IModifyPermissionCommand _modifyPermissionCommand;
        private readonly ElasticsearchClient _client;
        private string _indexName;

        public ModifyPermissionHandler(IModifyPermissionCommand modifyPermissionCommand, string urlElasticsearch, string indexName)
        {
            _modifyPermissionCommand = modifyPermissionCommand;
            _client = new ElasticsearchClient(new Uri(urlElasticsearch));
            _indexName = indexName;
        }

        public async Task<PermissionDto> Handle(int id, PermissionDto permission)
        {
            var index = await _client.Indices.GetAsync(_indexName);

            if (!index.IsValidResponse)
                await _client.Indices.CreateAsync(_indexName);

            var permissionModified = await _modifyPermissionCommand.Execute(id, permission);
            var indexResponse = await _client.UpdateAsync<PermissionDto, PermissionDto>(_indexName, id, p => p.Doc(permissionModified));
            return permissionModified;
        }
    }
}
