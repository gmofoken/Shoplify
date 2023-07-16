using System.ComponentModel.DataAnnotations;

namespace Shoplify.Models
{
    public class Test
    {
        [Key]
        public Int64 ID { get; set; }
        public int MyProperty { get; set; }
    }
}
