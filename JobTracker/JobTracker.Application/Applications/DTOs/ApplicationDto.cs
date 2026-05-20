namespace JobTracker.Application.Applications.DTOs;

public class ApplicationDto
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime AppliedDate { get; set; }
    public string Notes { get; set; } = string.Empty;
}