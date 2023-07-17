using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Shoplify.Models;
using Shoplify.Models.DTOs;
using Shoplify.Ochestration.ProductsOchestration.ProductsInterface;
using Shoplify.Services.DataServices.ProductsDataServices.ProductsDataServicesInterface;

namespace Shoplify.Ochestration.ProductsOchestration.ProductsImplementation
{
    public class ProductsOchestration : IProductsOchestration
    {
        private readonly IProductsDataService _ProductsDataService;
        private readonly IMapper _Mapper;

        public ProductsOchestration(IProductsDataService productsDataService, IMapper mapper)
        {
            _ProductsDataService = productsDataService;
            _Mapper = mapper;
        }


        public string AddProduct(Product product)
        {
            var products = _Mapper.Map<Products>(product);

            if (_ProductsDataService.AddProduct(products))
                return $"Succesfully created product{product.ProductName}";

            return $"Failed to create product{product.ProductName}";
        }
    }
}
