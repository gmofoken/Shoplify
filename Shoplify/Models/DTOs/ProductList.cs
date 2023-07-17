namespace Shoplify.Models.DTOs
{
    public class ProductList
    {
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ReferenceID { get; set; }
    }
}
