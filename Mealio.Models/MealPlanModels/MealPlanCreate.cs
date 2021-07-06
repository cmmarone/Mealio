using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mealio.Models.MealPlanModels
{
    public class MealPlanCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartingSunday { get; set; }
        [Required]
        public int LengthInWeeks { get; set; }
    }
}
