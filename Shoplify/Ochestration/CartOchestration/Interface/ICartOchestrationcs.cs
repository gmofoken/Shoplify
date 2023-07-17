using Shoplify.Models.DTOs;

namespace Shoplify.Ochestration.CartOchestration.Interface
{
    public interface ICartOchestrationcs
    {
        public string CreateCart(AddItem items, string userName);
        public List<Models.DTOs.Item> ListItems(string userName);
        public string RemoveItem(Int64 itemId, string userName);
    }
}
