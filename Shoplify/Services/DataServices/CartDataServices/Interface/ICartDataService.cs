using Shoplify.Models;

namespace Shoplify.Services.DataServices.CartDataServices.Interface
{
    public interface ICartDataService
    {
        public List<Item> GetProducts(Int64 userID);
        public Cart LookUpCart(Int64 userID);
        public bool AddToCart(Cart cart);
        public bool CreateCart(Cart cart);
    }
}
