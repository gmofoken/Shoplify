using System.ComponentModel.DataAnnotations;

namespace Shoplify.Models
{
    public class Users : Base
    {
        [Key]
        public Int64 UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
