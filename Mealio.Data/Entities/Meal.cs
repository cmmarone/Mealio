using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mealio.Data.Entities
{
    public enum MealType { Breakfast, Lunch, Dinner }

    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public string CookingInstructions { get; set; }
        [ForeignKey(nameof(MealPlan))]
        public int MealPlanId { get; set; }
        public int PlanDayIndex { get; set; }
        public Guid UserId { get; set; }

        // nav props
        public virtual MealPlan MealPlan { get; set; }
        public virtual ICollection<MealIngredient> MealIngredients { get; set; } = new List<MealIngredient>();
    }
}
