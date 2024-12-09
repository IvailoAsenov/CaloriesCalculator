using Microsoft.AspNetCore.Identity;

namespace CaloriesCalculator.Models
{
    public class AdminAction
    {
        public int Id { get; set; }
        public string AdminId { get; set; } 
        public DateTime ActionDate { get; set; } 
        public string ActionType { get; set; } 
        public string Details { get; set; } 
        public virtual IdentityUser Admin { get; set; } 
    }
}
