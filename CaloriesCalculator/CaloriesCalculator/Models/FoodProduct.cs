namespace CaloriesCalculator.Models
{
    public class FoodProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public decimal Calories { get; set; }  
        public decimal Protein { get; set; }    
        public decimal Carbs { get; set; }      
        public decimal Fat { get; set; }        
        public int CategoryId { get; set; }    

        public Category Category { get; set; } 
        public ICollection<MealFoodProduct> MealFoodProducts { get; set; }  
    }

}
