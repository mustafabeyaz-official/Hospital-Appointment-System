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
        IUserProfileManager _userProfileManager;
        public RegisterController(IUserManager userManager, IUserProfileManager userProfileManager)
        {
            _userManager = userManager;
            _userProfileManager = userProfileManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegisterRequestModel model)
        {
            User user = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = model.Password
            };
            bool result = await _userManager.CreateUserAsync(user);

            UserProfile userProfile = new()
            {
                ID = user.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            bool result2 = await _userProfileManager.CreateUserProfileAsync(userProfile);

            if (result & result2)
            {
                return Ok("user registeration success");
            }
            return BadRequest("an error occured");
        }
    }
}
