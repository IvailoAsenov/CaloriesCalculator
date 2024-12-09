public class FoodProduct
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Calories { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}
