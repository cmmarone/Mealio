using Mealio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mealio.Models.MealPlanModels
{
    public class MealPlanListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LengthInWeeks { get; set; }
    }
}
