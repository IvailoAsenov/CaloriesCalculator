using Microsoft.AspNetCore.Identity;

public class AdminActions
{
    public int Id { get; set; }
    public string ActionName { get; set; }
    public string Description { get; set; }
    public string AdminId { get; set; }
    public IdentityUser Admin { get; set; }  
}
