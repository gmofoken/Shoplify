namespace Shoplify.Models
{
    public class Base
    {
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; } = true;
        public bool IsComplete { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
