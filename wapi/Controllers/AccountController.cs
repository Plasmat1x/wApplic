using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using wapi.Domain.Entities.Idenity;
using wapi.Models;

namespace wapi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class AccountController: ControllerBase {
        private readonly UserManager<AppUser> umgr;
        private readonly RoleManager<IdentityRole> rmgr;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration,
            ILogger<AccountController> _logger, UserManager<AppUser> umgr, RoleManager<IdentityRole> rmgr) {
            this.umgr = umgr;
            this.rmgr = rmgr;
            this._logger = _logger;
            this._configuration = configuration;
        }

        [HttpGet("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model, CancellationToken ct) {

            var userExists = await umgr.FindByEmailAsync(model.Email);

            if(userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again" });

            AppUser user = new AppUser {
                Email = model.Email,
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var res = await umgr.CreateAsync(user, model.Password);

            if(!res.Succeeded) {

                if(!await rmgr.RoleExistsAsync("user"))
                    await rmgr.CreateAsync(new IdentityRole("user"));

                if(await rmgr.RoleExistsAsync("user")) {
                    await umgr.AddToRoleAsync(user, "user");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }

            return Ok(new Response { Status = "Success", Message = "User created success fully!" });
        }

        [HttpGet("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model, CancellationToken ct) {
            var userExist = await umgr.FindByNameAsync(model.Username);
            if(userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User alredy exists!" });

            AppUser user = new() {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await umgr.CreateAsync(user, model.Password);
            if(!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user detail and try again." });

            if(!await rmgr.RoleExistsAsync("admin"))
                await rmgr.CreateAsync(new IdentityRole("admin"));
            if(!await rmgr.RoleExistsAsync("user"))
                await rmgr.CreateAsync(new IdentityRole("user"));

            if(await rmgr.RoleExistsAsync("admin")) {
                await umgr.AddToRoleAsync(user, "admin");
            }
            if(await rmgr.RoleExistsAsync("user")) {
                await umgr.AddToRoleAsync(user, "user");
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model, CancellationToken ct) {

            var user = await umgr.FindByNameAsync(model.Username);

            if(user != null && await umgr.CheckPasswordAsync(user, model.Password)) {

                var userRoles = await umgr.GetRolesAsync(user);

                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach(var userRole in userRoles) {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims) {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}

