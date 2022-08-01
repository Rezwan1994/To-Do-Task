using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApi.Model;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(IConfiguration configuration,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        private async Task<string?> CreateTokenAsync(string? email, string? password)
        {
            if (email != null && password != null)
            {

                var user = await _userManager.FindByEmailAsync(email);
                var result = await _signInManager.CheckPasswordSignInAsync(user, password, true);

                if (result != null && result.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity((await _userManager.GetClaimsAsync(user)).ToArray()),
                        Issuer = _configuration["Jwt:Issuer"],
                        Audience = _configuration["Jwt:Audience"],
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return tokenHandler.WriteToken(token);
                }
                else
                {
                    return "Invalid credentials";
                }
            }
            else
            {
                return null;
            }
        }


        [HttpPost("adminregister")]
        public async Task<ActionResult<UserDto>> AdminRegister()
        {
            var appUser = new IdentityUser()
            {
                Email = "rezwan.aiub10@gmail.com",
                UserName = "Rezwan",
                PhoneNumber = "01750425444",
                
            };
            var result = _userManager.CreateAsync(appUser, "Rezwan10*");
            
            if (!result.Result.Succeeded)
            {
                return BadRequest();
            }
            else
            {
                await _userManager.AddToRolesAsync(appUser, new string[] { "Admin" });
                return new UserDto
                {
                    Email = appUser.Email
                };
            }

        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register()
        {
            var appUser = new IdentityUser()
            {
                Email = "shifat.aiub10@gmail.com",
                UserName = "Shifat",
                PhoneNumber = "0175042344",

            };
            var result = _userManager.CreateAsync(appUser, "Shifat10*");

            if (!result.Result.Succeeded)
            {
                return BadRequest();
            }
            else
            {
                await _userManager.AddToRolesAsync(appUser, new string[] { "Regular" });
                return new UserDto
                {
                    Email = appUser.Email
                };
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            try
            {

                var user = await _userManager.FindByNameAsync(loginDto.userName);
                var role = await _userManager.IsInRoleAsync(user,"Admin");
                if (user == null) return Unauthorized("");

              
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.password, lockoutOnFailure: true);

                if (!result.Succeeded) return Unauthorized("");
         
              
                return new UserDto
                {
                    Email = user.Email,
                    //Email = user.Email,
                    Token = await CreateTokenAsync(user.Email, loginDto.password),
                    DisplayName = user.UserName,
                    isAdmin = role
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
