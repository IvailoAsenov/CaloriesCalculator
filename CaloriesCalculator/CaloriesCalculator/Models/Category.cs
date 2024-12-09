using CaloriesCalculator.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; 
    public ICollection<FoodProduct> FoodProducts { get; set; } = new List<FoodProduct>();
}
