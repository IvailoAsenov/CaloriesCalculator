using Microsoft.AspNetCore.Identity;

public class UserProgress
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public IdentityUser User { get; set; } 
    public ICollection<ProgressEntry> ProgressEntries { get; set; }     
}
