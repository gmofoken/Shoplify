namespace Shoplify.Models
{
    public class Base
    {
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
        public bool IsComplete { get; set; }
    }
}
