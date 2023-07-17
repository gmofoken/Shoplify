using Microsoft.EntityFrameworkCore;
using Shoplify.Data;
using Shoplify.Models;
using Shoplify.Services.DataServices.CartDataServices.Interface;

namespace Shoplify.Services.DataServices.CartDataServices.Implementation
{
    public class CartDataService : ICartDataService
    {
        public readonly DbContextOptionsBuilder<ShoplifyContext> _DataContext;
        public readonly IConfiguration _Configuration;

        public CartDataService(IConfiguration configuration) 
        {
            _Configuration = configuration;
            _DataContext = new DbContextOptionsBuilder<ShoplifyContext>();
            _DataContext.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));
        }

        public bool CreateCart(Cart cart)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                context.Cart.Add(cart);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddToCart(Cart cart)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                context.Cart.Update(cart);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Cart LookUpCart(Int64 userID)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                return context.Cart.Where(x => x.UserId == userID && x.Active).Include(i => i.Items).FirstOrDefault();
            }
        }

        public List<Item> GetProducts(Int64 userID)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                var cart = context.Cart.Where(x => x.UserId == userID && x.Active).Include(p => p.Items).ToListAsync().Result;
                //var productIDs = cart.P

                return cart[0].Items;
            }
        }

        public bool CancelCart()
        {
            return false;
        }

        public bool CheckOut()
        {
            return false;
        }
    }
}
