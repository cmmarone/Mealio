using Mealio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mealio.Models.MealModels
{
    public class MealListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public string MealPlan { get; set; } // will get mapped as "No Plan" if Meal is unassigned
    }
}
