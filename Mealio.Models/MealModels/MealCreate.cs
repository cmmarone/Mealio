using Mealio.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mealio.Models.MealModels
{
    public class MealCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public MealType MealType { get; set; }
        [Required]
        public string MealPlan { get; set; }
        [Required]
        public int PlanDayIndex { get; set; }

        // CookingInstructions added after adding meal ingredients
    }
}
