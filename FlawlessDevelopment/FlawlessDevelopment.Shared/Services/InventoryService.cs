//using Azure.Data.Tables;
using FlawlessDevelopment.Shared.Models;
using System.Net.Http.Json;
//using static System.Net.WebRequestMethods;

namespace FlawlessDevelopment.Shared.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient _http;
        //private readonly TableClient _tableClient;

        // TableClient is configured via DI (see Program.cs)
        public InventoryService(HttpClient http)//,TableClient tableClient)
        {
            _http = http;
            //_tableClient = tableClient;
        }

        ///// <summary>
        ///// Queries the Azure Table Storage for all InventoryItem with the given PartitionKey (storeName).
        ///// </summary>
        //public async Task<IEnumerable<InventoryItem>> GetItemsByStoreAsync(string storeName)
        //{
        //    // Use QueryAsync with a LINQ filter on PartitionKey:contentReference[oaicite:8]{index=8}.
        //    var queryResults = _tableClient.QueryAsync<InventoryItem>(item => item.PartitionKey == storeName);

        //    var items = new List<InventoryItem>();
        //    await foreach (InventoryItem item in queryResults)
        //    {
        //        items.Add(item);
        //    }
        //    return items;
        //}
        public async Task<IEnumerable<InventoryItem>> GetItemsByStoreAsync(string storeName)
        {
            return await _http.GetFromJsonAsync<List<InventoryItem>>($"api/inventory/{storeName}");
        }

        //public async Task SaveItemToStoreAsync(InventoryItem entity)
        //{
        //    if (string.IsNullOrWhiteSpace(entity.PartitionKey))
        //        throw new ArgumentException("PartitionKey (store name) is required.");
        //    if (string.IsNullOrWhiteSpace(entity.RowKey))
        //        entity.RowKey = Guid.NewGuid().ToString(); // Generate if not provided

        //    await _tableClient.UpsertEntityAsync(entity);
        //}
    }
}
