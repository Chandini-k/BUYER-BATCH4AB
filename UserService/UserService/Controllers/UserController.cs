using System.Threading.Tasks;
using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.Manager;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _iUserManager;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger,IUserManager iUserManager)
        {
            _logger = logger;
            _iUserManager = iUserManager;
        }
        /// <summary>
        /// Register buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Buyer(BuyerRegister buyer)
        {

           _logger.LogInformation("Register");
            if (buyer is null)
            {
                return BadRequest("Buyer already exists");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           _logger.LogInformation("Succesfully Registered");
            return Ok(await _iUserManager.BuyerRegister(buyer));

        }
        /// <summary>
        /// Login Buyer
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> BuyerLogin(Login login)
        {
            _logger.LogInformation("User Login");

            Login login1 = await _iUserManager.BuyerLogin(login);
            if (login1 == null)
            {
                return Ok("Invalid User");
            }
            _logger.LogInformation($"Welcome{login.userName}");
            return Ok(login);
        }
    }
}