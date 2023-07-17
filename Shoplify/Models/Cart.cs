using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoplify.Models
{
    public class Cart : Base
    {
        [Key]
        public Int64 CartID { get; set; }
        public Int64 UserId { get; set; }
        public decimal TotalValue { get; set; }

        public List<Item> Items { get; set; }
    }

    public class Item : Base
    {
        [Key]
        public Int64 ItemID { get; set; }
        public Int64 ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
