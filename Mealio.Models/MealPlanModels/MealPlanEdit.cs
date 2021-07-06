using System;
using System.Collections.Generic;
using System.Text;

namespace Mealio.Models.MealPlanModels
{
    public class MealPlanEdit
    {
        public string Name { get; set; }
        public DateTime StartingSunday { get; set; }
        public int LengthInWeeks { get; set; }
    }
}
