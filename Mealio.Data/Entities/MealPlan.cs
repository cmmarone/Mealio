using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mealio.Data.Entities
{
    public class MealPlan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int LengthInWeeks { get; set; }
        public Guid UserId { get; set; }

        // nav props
        public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();
        public virtual ICollection<GroceryList> GroceryLists { get; set; } = new List<GroceryList>();
    }
}