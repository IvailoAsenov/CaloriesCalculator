﻿namespace CaloriesCalculator.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Description { get; set; }  

        public ICollection<MealFoodProduct> MealFoodProducts { get; set; }  
    }

}
