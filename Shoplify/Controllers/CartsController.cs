using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("ListItems")]
        [Authorize]
        public ActionResult ListProducts()
        {
            try
            {

                return Ok(_CartOchestration.ListItems(this.User.Identity.Name));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }


        [HttpPost("AddItem")]
        [Authorize]
        public ActionResult CreateProduct(AddItem items)
        {
            try
            {

                return Ok(_CartOchestration.CreateCart(items, this.User.Identity.Name));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }


        [HttpGet("RemoveItem")]
        [Authorize]
        public ActionResult RemoveItem(Int64 itemID)
        {
            try
            {

                return Ok(_CartOchestration.RemoveItem(itemID, "string"));
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
