using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Users.RequestModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IUserManager _userManager;
        public RegisterController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel item)
        {
            User user = new()
            {
                UserName = item.UserName,
                Email = item.Email,
                PasswordHash = item.Password
            };

            bool result = await _userManager.CreateUserAsync(user);
            if (result)
            {
                return Ok("user registeration succesful");
            }
            return BadRequest("error occured while registeration");
        }
    }
}
