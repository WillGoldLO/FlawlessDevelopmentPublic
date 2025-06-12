//using Azure.Data.Tables;
using FlawlessDevelopment.Shared.Models;
using System.Net.Http.Json;
//using static System.Net.WebRequestMethods;

namespace FlawlessDevelopment.Shared.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient _http;

        public InventoryService(HttpClient http)
        {
            _http = http;
        }

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
