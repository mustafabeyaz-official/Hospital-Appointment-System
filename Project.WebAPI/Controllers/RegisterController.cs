using Microsoft.AspNetCore.Http;
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
        public RegisterController(IUserManager manager)
        {
            _userManager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserRegisterRequestModel model)
        {
            User user = new() 
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = model.Password
            };
            
            bool result = await _userManager.CreateUserAsync(user);
            if(result)
            {
                return Ok("user registeration success");
            }
            return BadRequest("an error occured");
        }
    }
}
