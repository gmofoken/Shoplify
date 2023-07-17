using Shoplify.Models.DTOs;

namespace Shoplify.Ochestration.ProductsOchestration.ProductsInterface
{
    public interface IProductsOchestration
    {
        public string AddProduct(Product product, string username);
        public List<ProductList> ListProducts(bool active, string userName);

        public string DeactivateProduct(Int64 productID, string userName);

        public string ActivateProduct(Int64 productID, string userName);
    }
}
