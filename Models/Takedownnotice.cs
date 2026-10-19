namespace Nyaya_Flow.Models
{
    public class Takedownnotice
    {
        public string CaseId { get; set; } = string.Empty;
        public string CaseName { get; set; } = string.Empty;
        public string ViolationType { get; set; } = string.Empty;

        public DateTime ReceivedAtUtc { get; set; }
        public DateTime DeadlineUtc { get; set; }

        public bool IsResolved { get; set; } = false;
        public DateTime CreatedAt { get; set; }


        // Dynamically calculates time remaining against UTC Now
        public TimeSpan TimeRemaining => DeadlineUtc > DateTime.UtcNow ? DeadlineUtc - DateTime.UtcNow : TimeSpan.Zero;
    }
}
