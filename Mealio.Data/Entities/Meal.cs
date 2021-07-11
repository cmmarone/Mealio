using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mealio.Data.Entities
{
    public enum MealType
    { 
        Breakfast,
        [Display(Name = "AM Snack")]
        AmSnack, 
        Lunch,
        [Display(Name = "PM Snack")]
        PmSnack,
        Dinner
    }

    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public string CookingInstructions { get; set; }
        [ForeignKey(nameof(MealPlan))]
        public int MealPlanId { get; set; }

        // int corresponding to day number of plan where first day of plan is 1. 
        // Ex: value of 6 could be Friday, Week 1 of a plan that starts on a Sunday
        //     or value of 11 could be Thursday, Week 2 of a plan that starts on a Monday
        public int PlanDayIndex { get; set; } 
        public Guid UserId { get; set; }

        // nav props
        public virtual MealPlan MealPlan { get; set; }
        public virtual ICollection<MealIngredient> MealIngredients { get; set; } = new List<MealIngredient>();
    }
}
