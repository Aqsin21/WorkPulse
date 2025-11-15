using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkPulse.API.Dtos.Auth;
using WorkPulse.BLL.Services.Concrete;
using WorkPulse.DAL.DataContext.Entities;
namespace WorkPulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly TokenService _tokenService;


        public AuthController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = new Employee
            {
                Email = dto.Email,
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                HourlyPrice = 0,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
           
            return Ok(new
            {
                Message = "Register is Successfull",

            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Unauthorized("Invalid Email or Password");
            if (!user.IsActive) return Unauthorized("Account wait Admin approval");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (result.Succeeded) return Unauthorized("Invalid Login Attempt");

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }
    }

}