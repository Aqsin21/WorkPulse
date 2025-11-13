namespace WorkPulse.DAL.DataContext.Entities
{
    public class PayRoll:BaseEntity
    {
        public required string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double TotalWorkedHours { get; set; }
        public double TotalOvertimeHours { get; set; }
        public double TotalLeaveDays { get; set; }
        public decimal TotalSalary { get; set; }

    }
}
