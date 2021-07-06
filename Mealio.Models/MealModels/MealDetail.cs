using Mealio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mealio.Models.MealModels
{
    public class MealDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public string MealPlan { get; set; }
        public string PlanDay { get; set; } // map as Ex: "Thursday, Week 2"
        public string CookingInstructions { get; set; }
        public List<string> MealIngredients { get; set; } // will get formatted in service layer
    }
}
