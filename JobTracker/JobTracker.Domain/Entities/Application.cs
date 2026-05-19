namespace JobTracker.Domain.Entities;

public class Application
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public Job Job { get; set; } = null!;
    public string Status { get; set; } = "Applied";
    public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
    public string Notes { get; set; } = string.Empty;
}