public class FoodProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Calories { get; set; } 
    public int CategoryId { get; set; }
    public Category Category { get; set; } 
}
