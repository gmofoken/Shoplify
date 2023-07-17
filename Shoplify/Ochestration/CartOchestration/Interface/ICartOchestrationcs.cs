using Shoplify.Models.DTOs;

namespace Shoplify.Ochestration.CartOchestration.Interface
{
    public interface ICartOchestrationcs
    {
        public string CreateCart(AddItem items, Int64 userID);
        public List<Models.DTOs.Item> ListItems(string UserID);
        public string RemoveItem(Int64 itemId, string userName);
    }
}
