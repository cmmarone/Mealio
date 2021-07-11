using Mealio.Data;
using Mealio.Models.MealPlanModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mealio.Services
{
    public class MealPlanService
    {
        private readonly ApplicationDbContext _context;
        private readonly Guid _userId;

        public MealPlanService(ApplicationDbContext context, Guid userId)
        {
            _context = context;
            _userId = userId;
        }

        //public IEnumerable<MealPlanListItem> GetMealPlans()
        //{

        //}

        //public MealPlanDetail GetMealPlanById(int id)
        //{

        //}

        //public bool CreateMealPlan()
        //{

        //}

        //public bool UpdateMealPlan(MealPlanEdit model)
        //{

        //}

        //public bool DeleteMealPlan(int id)
        //{

        //}
    }
}
