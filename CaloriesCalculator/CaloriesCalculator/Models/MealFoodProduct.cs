namespace CaloriesCalculator.Models
{
    public class MealFoodProduct
    {
        public int MealId { get; set; }
        public Meal Meal { get; set; } 

        public int FoodProductId { get; set; }
        public FoodProduct FoodProduct { get; set; }  
    }

}
