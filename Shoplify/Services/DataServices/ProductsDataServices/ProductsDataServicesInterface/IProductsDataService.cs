using Shoplify.Models;

namespace Shoplify.Services.DataServices.ProductsDataServices.ProductsDataServicesInterface
{
    public interface IProductsDataService
    {
        public bool AddProduct(Products product);
        public Products GetProduct(Int64 productID);
        public List<Products> GetActiveProducts();
        public List<Products> GetInActiveProducts();
        public bool ActivateProduct(Products product);
        public bool DeactivateProduct(Products product);
    }
}
