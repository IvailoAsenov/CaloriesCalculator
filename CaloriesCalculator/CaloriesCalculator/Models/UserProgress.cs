using Microsoft.AspNetCore.Identity;

public class UserProgress
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int ConsumedCalories { get; set; }
    public int WeeklyGoal { get; set; } 
    public virtual IdentityUser User { get; set; } = null!;
}
