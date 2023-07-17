using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Shoplify.Models;
using Shoplify.Models.DTOs;
using Shoplify.Ochestration.ProductsOchestration.ProductsInterface;
using Shoplify.Services.DataServices.ProductsDataServices.ProductsDataServicesInterface;
using Shoplify.Services.DataServices.UsersDataServices.Interface;

namespace Shoplify.Ochestration.ProductsOchestration.ProductsImplementation
{
    public class ProductsOchestration : IProductsOchestration
    {
        private readonly IProductsDataService _ProductsDataService;
        private readonly IUserDataService _UsersDataService;
        private readonly IMapper _Mapper;

        public ProductsOchestration(IProductsDataService productsDataService, IMapper mapper, IUserDataService userDataService)
        {
            _ProductsDataService = productsDataService;
            _Mapper = mapper;
            _UsersDataService = userDataService;
        }


        public string AddProduct(Product product, string userName)
        {
            var user = _UsersDataService.GetUser(userName);

            if (user == null && !user.IsAdmin)
                return $"You need to be admin to add products";

            var products = _Mapper.Map<Products>(product);

            if (product.Price <= 0)
                return $"You cant load a product with a zero value";

            products.CreatedBy = userName;
            products.ModifiedBy = userName;

            if (_ProductsDataService.AddProduct(products))
                return $"Succesfully created product{product.ProductName}";

            return $"Failed to create product{product.ProductName}";
        }

        public string ActivateProduct(Int64 productID, string userName)
        {
            var user = _UsersDataService.GetUser(userName);

            if (user == null && !user.IsAdmin)
                return $"You need to be admin to add products";

            var product = _ProductsDataService.GetProduct(productID);

            if (product == null)
                return "product not available/does not exist";

            product.ModifiedBy = userName;
            product.Active = true;

            if (_ProductsDataService.ActivateProduct(product))
                return $"Product succesfully updated";

            return $"Failed to create product{product.ProductName}";
        }

        public List<Product> ListProducts(bool active, string userName)
        {
            var user = _UsersDataService.GetUser(userName);

            if (user != null && !user.IsAdmin)
                throw new Exception("Permission Denied");

            List<Products> productList;

            if (active)
                productList = _ProductsDataService.GetActiveProducts();
            else
                productList = _ProductsDataService.GetInActiveProducts();

            List<Product> products = new List<Product>();
            foreach (var item in productList)
            {
                products.Add(_Mapper.Map<Product>(item));
            }

            return products;
        }

        public string DeactivateProduct(Int64 productID, string userName)
        {
            var user = _UsersDataService.GetUser(userName);

            if (user == null && !user.IsAdmin)
                return $"You need to be admin to add products";

            var product = _ProductsDataService.GetProduct(productID);

            if (product == null)
                return "product not available/does not exist";

            product.ModifiedBy = userName;
            product.Active = false;

            if (_ProductsDataService.DeactivateProduct(product))
                return $"Product succesfully updated";

            return $"Failed to update product";
        }
    }
}
