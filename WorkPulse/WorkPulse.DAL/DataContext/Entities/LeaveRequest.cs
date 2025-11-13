namespace WorkPulse.DAL.DataContext.Entities
{
    public class LeaveRequest:BaseEntity
    {
        public required string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required string LeaveType { get; set; } 
        public string Status { get; set; }   
        public string? Reason { get; set; }
    }
}
