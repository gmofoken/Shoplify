using AutoMapper;
using Shoplify.Models;
using Shoplify.Models.DTOs;
using Shoplify.Ochestration.CartOchestration.Interface;
using Shoplify.Services.DataServices.CartDataServices.Interface;

namespace Shoplify.Ochestration.CartOchestration.Implementation
{
    public class CartOchestration : ICartOchestrationcs
    {
        private readonly ICartDataService _CartDataService;
        private readonly IMapper _Mapper;

        public CartOchestration(ICartDataService cartDataService, IMapper mapper)
        {
            _Mapper = mapper;
            _CartDataService = cartDataService;
        }

        public List<Models.DTOs.Item> ListItems(Int64 UserID)
        {
            try
            {
                var results = _CartDataService.GetProducts(UserID);

                List<Models.DTOs.Item> items = new List<Models.DTOs.Item>();
                items.ForEach(x => items.Add(_Mapper.Map<Models.DTOs.Item>(x)));
                return items;
            }
            catch (Exception)
            {
                throw (new Exception("Error retrieving cart"));
            }
        }

        public string CreateCart(Models.DTOs.Item product, Int64 userID)
        {
            var cart = _CartDataService.LookUpCart(1);
            if (cart != null && cart.Active)
            {
                cart.Items.Add(new Models.Item() { ProductID = product.ProductID, Description = product.Description, Price = product.Price });
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
                    TotalValue = product.Price,
                    Items = new List<Models.Item>() { new Models.Item() { ProductID = product.ProductID, Description = product.Description, Price = product.Price } }
                };

                bool added = _CartDataService.AddToCart(newCart);
                if (added)
                    return $"Succesfully created product{product.Description}";
            }
                

            return $"Failed to create product{product.Description}";
        }
    }
}
