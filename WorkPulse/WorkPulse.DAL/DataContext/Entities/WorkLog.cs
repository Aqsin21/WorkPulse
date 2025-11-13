namespace WorkPulse.DAL.DataContext.Entities
{
    public class WorkLog:BaseEntity
    {
        public string EmployeeId { get; set; } = null!;

        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public double BreakDuration { get; set; }
        public double TotalWorkedHours { get; set; }
        public bool IsOvertime { get; set; }
        public double? OvertimeHours { get; set; }
        public Employee Employee { get; set; } = null!;

    }
}
