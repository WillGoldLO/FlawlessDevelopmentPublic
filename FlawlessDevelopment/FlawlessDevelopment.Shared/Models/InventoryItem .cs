using Azure;
using Azure.Data.Tables;

namespace FlawlessDevelopment.Shared.Models
{
    public class InventoryItem : ITableEntity
    {
        public string PartitionKey { get; set; } // store name (e.g., "Clothing")
        public string RowKey { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Size { get; set; }
        public string? ImageUrl { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}