using Microsoft.AspNetCore.Identity;

namespace CaloriesCalculator.Models
{
    public class UserSettings
    {
        public int Id { get; set; }
        public string UserId { get; set; }  
        public int TargetCalories { get; set; } 
        public int WeeklyTargetCalories { get; set; }  
        public virtual IdentityUser User { get; set; }  
    }
}
