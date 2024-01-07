using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using wapi.Domain.Entities.Idenity;
using wapi.Models;

namespace wapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly UserManager<AppUser> userManager;

        public UserController(ILogger<UserController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            this.userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }
            return Ok(new UserModel { CreatedAt = user.CreatedAt, Username = user.UserName, Avatar = user.Avatar });
        }
    }
}
