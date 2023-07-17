using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shoplify.Data;
using Shoplify.Models;
using Shoplify.Models.DTOs;
using Shoplify.Ochestration.CartOchestration.Implementation;
using Shoplify.Ochestration.CartOchestration.Interface;
using Item = Shoplify.Models.DTOs.Item;

namespace Shoplify.Controllers
{
    public class CartsController : ControllerBase
    {
        private readonly ICartOchestrationcs _CartOchestration;

        public CartsController(ICartOchestrationcs cartOchestrationcs)
        {
            _CartOchestration = cartOchestrationcs;
        }

        [HttpGet("ListProducts")]
        //[DisableCors]
        //[Authorize]
        public ActionResult ListProducts()
        {
            try
            {

                return Ok(_CartOchestration.ListItems(1));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }


        [HttpPost("AddProduct")]
        //[DisableCors]
        //[Authorize]
        public ActionResult CreateProduct(Item product)
        {
            try
            {

                return Ok(_CartOchestration.CreateCart(product, 1));
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
