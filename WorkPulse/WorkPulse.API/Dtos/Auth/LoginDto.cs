using System.ComponentModel.DataAnnotations;

namespace WorkPulse.API.Dtos.Auth
{
    public class LoginDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
