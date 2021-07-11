using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mealio.Models.MealIngredientModels
{
    public class MealIngredientCreate
    {
        [Required]
        public string Ingredient { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Units { get; set; }
    }
}
