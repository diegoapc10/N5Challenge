using Aplication.Handlers;
using Azure.Core;
using Confluent.Kafka;
using Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace N5ChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly RequestPermissionHandler _permissionHandler;
        private readonly ModifyPermissionHandler _modifyPermissionHandler;
        private readonly GetPermissionsHandler _getPermissionsHandler;

        public PermissionController(RequestPermissionHandler permissionHandler, ModifyPermissionHandler modifyPermissionHandler, GetPermissionsHandler getPermissionsHandler)
        {
            _permissionHandler = permissionHandler;
            _modifyPermissionHandler = modifyPermissionHandler;
            _getPermissionsHandler = getPermissionsHandler;
        }

        [HttpPost]
        public async Task<IActionResult> RequestPermission(PermissionDto permission)
        {
            Log.Information("Operation: RequestPermission => New Permission:{@permission}", permission);
            var response = await _permissionHandler.Handle(permission);

            if (response == null)
                return BadRequest();

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                AllowAutoCreateTopics = true,
                Acks = Acks.All
            };

            var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                var deliveryResult = await producer.ProduceAsync(topic: "Operations",
                    new Message<Null, string>
                    {
                        Value = "{ id: " + Guid.NewGuid().ToString() + ", nameOperation: request }"
                    });
            }
            catch (ProduceException<Null, string> e)
            {
                Log.Error($"Delivery failed: {e.Error.Reason}");
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ModifyPermission(int id, PermissionDto permission)
        {
            Log.Information("Operation: ModifyPermission => Id:{@id}, Permission:{@permission}", id, permission);
            var response = await _modifyPermissionHandler.Handle(id, permission);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var response = await _getPermissionsHandler.Handle();

            Log.Information("Operation: GetPermissions => {@response}", response);

            if (response == null || !response.Any())
                return BadRequest();

            //var config = new ProducerConfig
            //{
            //    BootstrapServers = "localhost:9092",
            //};

            //using(var producer = new ProducerBuilder<Null, string>(config).Build())
            //{
            //    try
            //    {
            //        var deliveryResult = await producer.ProduceAsync(topic: "Operations",
            //            new Message<Null, string>
            //            {
            //                Value = "{ id: " + Guid.NewGuid().ToString() + ", nameOperation: get }"
            //            });
            //    }
            //    catch (ProduceException<Null, string> e)
            //    {
            //        Log.Error($"Delivery failed: {e.Error.Reason}");
            //    }
            //}

            return Ok(response);
        }
    }
}
