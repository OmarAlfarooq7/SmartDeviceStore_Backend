namespace SmartDevicesStore.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // علاقة: الصنف الواحد يحتوي على قائمة منتجات
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}