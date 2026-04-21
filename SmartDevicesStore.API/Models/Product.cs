using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDevicesStore.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        // الربط مع جدول الأصناف
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}