using System;
using System.Collections.Generic;
using System.Text;

namespace Mealio.Models.MealIngredientModels
{
    public class MealIngredientEdit
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int Amount { get; set; }
        public string Units { get; set; }
    }
}
