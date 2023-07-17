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
        //[Authorize]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                return Ok(_ProductsOchestration.AddProduct(product, "string"));
            }
            catch(Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPut("DeActivateProduct")]
        //[Authorize]
        public ActionResult DeActivateProduct(Int64 ProductID)
        {
            try
            {
                return Ok(_ProductsOchestration.DeactivateProduct(ProductID, "string"));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPut("ActivateProduct")]
        //[Authorize]
        public ActionResult ActivateProduct(Int64 ProductID)
        {
            try
            {
                return Ok(_ProductsOchestration.ActivateProduct(ProductID, "string"));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpGet("ListProdcts")]
        //[Authorize]
        public ActionResult ListProdcts(bool active)
        {
            try
            {
                return Ok(_ProductsOchestration.ListProducts(active, "string"));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
