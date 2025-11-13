using Microsoft.AspNetCore.Identity;
namespace WorkPulse.DAL.DataContext.Entities
{
    public class Employee:IdentityUser
    {
        public  required string UserName {  get; set; }
        public required  string FirstName { get; set; }
        public required string LastName { get; set; }
        public required decimal HourlyPrice { get; set; }
        public bool IsActive { get; set; }

    }
}
