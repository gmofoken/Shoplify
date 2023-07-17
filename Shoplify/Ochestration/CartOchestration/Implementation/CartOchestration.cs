using AutoMapper;
using Shoplify.Models;
using Shoplify.Models.DTOs;
using Shoplify.Ochestration.CartOchestration.Interface;
using Shoplify.Services.DataServices.CartDataServices.Interface;
using Shoplify.Services.DataServices.ProductsDataServices.ProductsDataServicesInterface;
using Shoplify.Services.DataServices.UsersDataServices.Interface;

namespace Shoplify.Ochestration.CartOchestration.Implementation
{
    public class CartOchestration : ICartOchestrationcs
    {
        private readonly ICartDataService _CartDataService;
        private readonly IUserDataService _UsersDataService;
        private readonly IProductsDataService _ProductDataService;
        private readonly IMapper _Mapper;

        public CartOchestration(ICartDataService cartDataService, IMapper mapper, IUserDataService userDataService, IProductsDataService productsDataService)
        {
            _Mapper = mapper;
            _CartDataService = cartDataService;
            _UsersDataService = userDataService;
            _ProductDataService = productsDataService;
        }

        public string RemoveItem(Int64 itemId, string userName)
        {
            try
            {
                var userID = _UsersDataService.GetUser(userName).UserID;
                _CartDataService.RemoveItem(itemId, userID);
            }
            catch (Exception ex)
            {
                throw (new Exception("Error removing item"));
            }

            return $"Item removed";
        }

        public List<Models.DTOs.Item> ListItems(string userName)
        {
            try
            {
                var userID = _UsersDataService.GetUser(userName).UserID;

                var results = _CartDataService.GetProducts(userID);

                List<Models.DTOs.Item> items = new List<Models.DTOs.Item>();
                foreach (var item in results)
                {
                    items.Add(_Mapper.Map<Models.DTOs.Item>(item));
                }

                return items;
            }
            catch (Exception)
            {
                throw (new Exception("Error retrieving cart"));
            }
        }

        public string CreateCart(AddItem items, string userName)
        {
            var cart = _CartDataService.LookUpCart(1);
            var product = _ProductDataService.GetProduct(items.ProductID);
            var userID = _UsersDataService.GetUser(userName).UserID;

            if (product == null)
                return $"product not available/does not exist";

            if (cart != null && cart.Active)
            {
                cart.Items.Add(new Models.Item() { ProductID = items.ProductID, Quantity = items.Quantity });
                bool added = _CartDataService.AddToCart(cart);
                if (added)
                    return $"Succesfully created product{product.Description}";
            }
            else
            {
                var newCart = new Cart()
                {
                    Active = true,
                    UserId = userID,
                    Items = new List<Models.Item>() { new Models.Item() { ProductID = items.ProductID, Quantity = items.Quantity } }
                };

                bool added = _CartDataService.AddToCart(newCart);
                if (added)
                    return $"Succesfully created product{product.Description}";
            }
                

            return $"Failed to create product{product.Description}";
        }
    }
}
