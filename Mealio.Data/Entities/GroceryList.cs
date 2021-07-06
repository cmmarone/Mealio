using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mealio.Data.Entities
{
    public class GroceryList
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(MealPlan))]
        public int MealPlanId { get; set; }
        public int WeekNumber { get; set; }
        public IEnumerable<string> OtherGroceries { get; set; }
        public Guid UserId { get; set; }

        // nav props
        public virtual ICollection<MealIngredient> MealIngredients { get; set; } = new List<MealIngredient>();
        public virtual MealPlan MealPlan { get; set; }
    }
}
