using Microsoft.AspNetCore.Identity;

public class ProgressEntry
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int Calories { get; set; } 
    public virtual IdentityUser User { get; set; } = null!;
}
