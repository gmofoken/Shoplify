using Microsoft.EntityFrameworkCore;
using Shoplify.Data;
using Shoplify.Models;
using Shoplify.Services.DataServices.ProductsDataServices.ProductsDataServicesInterface;

namespace Shoplify.Services.DataServices.ProductsDataServices.ProductsDataServicesImplementation
{

    public class ProductsDataService : IProductsDataService
    {
        public readonly DbContextOptionsBuilder<ShoplifyContext> _DataContext;
        public readonly IConfiguration _Configuration;

        public ProductsDataService(IConfiguration configuration)
        {
            _Configuration = configuration;
            _DataContext = new DbContextOptionsBuilder<ShoplifyContext>();
            _DataContext.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));
        }

        public bool AddProduct(Products product)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ActivateProduct(Products product)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                context.Products.Update(product);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeactivateProduct(Products product)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                context.Products.Update(product);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Products GetProduct(Int64 productID)
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                return context.Products.FindAsync(productID).Result;
            }
        }

        public List<Products> GetActiveProducts()
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                return context.Products.Where(x => x.Active).ToListAsync().Result;
            }
        }

        public List<Products> GetInActiveProducts()
        {
            using (ShoplifyContext context = new ShoplifyContext(_DataContext.Options))
            {
                return context.Products.Where(x => !x.Active).ToListAsync().Result;
            }
        }
    }
}
