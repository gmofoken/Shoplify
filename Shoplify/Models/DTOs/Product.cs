namespace Shoplify.Models.DTOs
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public string ReferenceID { get; set; }
    }
}
