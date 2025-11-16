using System.ComponentModel.DataAnnotations;

namespace WorkPulse.API.Dtos.Auth
{
    public class ApproveUserDto
    {
        [Range(0.01, 1000, ErrorMessage = "The hourly wage must be between 0.01-1000")]
        public required decimal HourlyPrice { get; set; }
    }
}
