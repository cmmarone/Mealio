using Mealio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mealio.Models.MealModels
{
    public class MealEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public string CookingInstructions { get; set; }
        public string MealPlan { get; set; }
        public int PlanDayIndex { get; set; }
    }
}
