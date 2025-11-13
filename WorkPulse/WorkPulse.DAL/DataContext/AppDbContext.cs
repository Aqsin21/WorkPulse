using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkPulse.DAL.DataContext.Entities;

namespace WorkPulse.DAL.DataContext
{
    public class AppDbContext:IdentityDbContext<Employee>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<PayRoll> PayRolls { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }
    }
}
