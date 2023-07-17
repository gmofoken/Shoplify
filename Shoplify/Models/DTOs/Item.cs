namespace Shoplify.Models.DTOs
{
    public class Item
    {
        public Int64 ProductID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Int64 ItemID { get; set; }
    }
}
