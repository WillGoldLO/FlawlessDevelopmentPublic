using FlawlessDevelopment.Shared.Models;

namespace FlawlessDevelopment.Shared.Services
{
    public interface IInventoryService
    {
        /// <summary>
        /// Retrieves all inventory items for a given store (PartitionKey).
        /// </summary>
        Task<IEnumerable<InventoryItem>> GetItemsByStoreAsync(string storeName);
    }
}
