using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoplify.Models;
using Shoplify.Models.DTOs;
using Shoplify.Ochestration.UsersOchestration.Interface;

namespace Shoplify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserOchestration _UserOchestration;

        public UsersController(IUserOchestration userOchestration)
        {
            _UserOchestration = userOchestration;
        }

        [HttpPost("CreateUser")]
        public ActionResult CreateUser(User user)
        {
            try
            {
                return Ok(_UserOchestration.CreateUser(user));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPost("ModifyUser")]
        public ActionResult ModifyUser(UserModify user)
        {
            try
            {
                return Ok(_UserOchestration.ModifyUser(user));
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
