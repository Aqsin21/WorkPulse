using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkPulse.API.Dtos.Auth;
using WorkPulse.DAL.DataContext.Entities;

namespace WorkPulse.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;

        public AdminController(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }
        [HttpPut("approve/userId")]
        public async Task<IActionResult> ApproveUser(string userId, [FromBody] ApproveUserDto dto)
        {
            var user =await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found");
            if (user.IsActive) return BadRequest("User already approved");
            user.IsActive = true;
            user.HourlyPrice = dto.HourlyPrice;
            var result =await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok(new
            {
                Message = "Approved",
                UserName = user.UserName,
                HourlyPrice = user.HourlyPrice
            });

        }
    }
}
