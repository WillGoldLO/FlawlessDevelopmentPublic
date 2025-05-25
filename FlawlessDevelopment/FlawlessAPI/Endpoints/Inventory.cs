using FlawlessDevelopment.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FlawlessDevelopment.API.Endpoints
{
    public class Inventory(ILogger<Inventory> logger)
    {
        private readonly ILogger<Inventory> _logger = logger;

        [Function("Inventory")]
        public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Inventory")]
        HttpRequestData req,
        FunctionContext executionContext)
        {
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            _logger.LogInformation("Inventory triggered.");
            try
            {
                var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
                string storeName = query["storeName"];

                //var mailRequest = JsonConvert.DeserializeObject<MailRequest>(requestBody) ?? throw new ArgumentException("Request body could not be deserialized.");

                //// RBAC validation, based on template chosen, load the template


                var items = new List<InventoryItem>()
                {
                    new InventoryItem (){PartitionKey=storeName,RowKey=Guid.NewGuid().ToString()},
                    new InventoryItem (){PartitionKey=storeName,RowKey=Guid.NewGuid().ToString()},
                    new InventoryItem (){PartitionKey=storeName,RowKey=Guid.NewGuid().ToString()}
                };

                //return new OkObjectResult(items);
                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(items);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error sending email: {message}", ex.Message);
                return null;
            }
        }

    }
}
