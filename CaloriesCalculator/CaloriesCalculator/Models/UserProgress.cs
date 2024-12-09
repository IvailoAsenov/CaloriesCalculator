using Microsoft.AspNetCore.Identity;

namespace CaloriesCalculator.Models
{
    public class UserProgress
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int ConsumedCalories { get; set; }
        public virtual IdentityUser User { get; set; }
        public List<UserProgress> Progress { get; set; }
        public int WeeklyGoal { get; set; }

    }
}

