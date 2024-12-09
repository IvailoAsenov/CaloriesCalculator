using Microsoft.AspNetCore.Identity;

public class AdminAction
{
    public int Id { get; set; }
    public string? AdminId { get; set; }
    public DateTime ActionDate { get; set; }
    public string ActionType { get; set; } = string.Empty; 
    public string Details { get; set; } = string.Empty; 
    public virtual IdentityUser? Admin { get; set; }
}
