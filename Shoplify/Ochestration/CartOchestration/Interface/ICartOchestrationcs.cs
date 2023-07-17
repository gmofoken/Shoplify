using Shoplify.Models.DTOs;

namespace Shoplify.Ochestration.CartOchestration.Interface
{
    public interface ICartOchestrationcs
    {
        public string CreateCart(Item product, Int64 userID);
        public List<Models.DTOs.Item> ListItems(Int64 UserID);
    }
}
