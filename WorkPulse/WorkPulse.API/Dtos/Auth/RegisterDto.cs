using System.ComponentModel.DataAnnotations;
namespace WorkPulse.API.Dtos.Auth
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "UserName must just letter and digit.")]
        public required string UserName { get; set; }

        [Required]
        [MinLength(5)]
        public required string Password { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

    }
}
