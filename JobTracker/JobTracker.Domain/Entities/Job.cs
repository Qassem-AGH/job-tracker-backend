using static System.Net.Mime.MediaTypeNames;

namespace JobTracker.Domain.Entities;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public ICollection<Application> Applications { get; set; } = new List<Application>();
}