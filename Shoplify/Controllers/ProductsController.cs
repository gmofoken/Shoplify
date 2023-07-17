using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoplify.Models.DTOs;
using Shoplify.Ochestration.ProductsOchestration.ProductsInterface;

namespace Shoplify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsOchestration _ProductsOchestration;

        public ProductsController(IProductsOchestration productsOchestration)
        {
            _ProductsOchestration = productsOchestration;
        }
        
        [HttpPost("CreateProduct")]
        [DisableCors]
        [Authorize]
        public ActionResult CreateProduct(Product product)
        {
            try
            {

                return Ok(_ProductsOchestration.AddProduct(product));
            }
            catch(Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
