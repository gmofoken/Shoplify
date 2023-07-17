using System.ComponentModel.DataAnnotations;

namespace Shoplify.Models
{
    public class Products : Base
    {
        [Key]
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public string ReferenceID { get; set; }
    }
}
