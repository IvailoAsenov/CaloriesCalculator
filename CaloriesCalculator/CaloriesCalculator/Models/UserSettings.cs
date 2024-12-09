using Microsoft.AspNetCore.Identity;

public class UserSettings
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public IdentityUser User { get; set; }  
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }
}
