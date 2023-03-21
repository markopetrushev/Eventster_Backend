using EventApp.Web.Data;
using EventApp.Web.Models.Domain;
using EventApp.Web.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _authContext;

        private readonly UserManager<EventsterApplicationUser> userManager;
        private readonly SignInManager<EventsterApplicationUser> signInManager;
        public AuthController(ApplicationDbContext applicationDbContext, UserManager<EventsterApplicationUser> userManager, SignInManager<EventsterApplicationUser> signInManager)
        {
            this._authContext = applicationDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] EventsterApplicationUser eventsterApplicationUser)
        {
            var user = await userManager.FindByNameAsync(eventsterApplicationUser.UserName);
            if (await userManager.CheckPasswordAsync(user, eventsterApplicationUser.Password) == false)
            {
                return BadRequest();
            }

            var result = await signInManager.PasswordSignInAsync(eventsterApplicationUser.UserName, eventsterApplicationUser.Password, true, true);

            if (result.Succeeded)
            {
                await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                return Ok(new
                {
                    Message = "Login Success!"
                });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser([FromBody] EventsterApplicationUser eventsterApplicationUser)
        {
            var userCheck = await userManager.FindByNameAsync(eventsterApplicationUser.UserName);
            if (userCheck == null)
            {
                var user = new EventsterApplicationUser
                {
                    EmailConfirmed = true,
                    UserCart = new ShoppingCart()
                };
                var result = await userManager.CreateAsync(user, eventsterApplicationUser.Password);
                return Ok(new
                {
                    Message = "Registration Success!"
                });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}