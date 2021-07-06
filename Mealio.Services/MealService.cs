using Mealio.Data;
using Mealio.Models.MealModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mealio.Services
{
    public class MealService
    {
        private readonly ApplicationDbContext _context;
        private readonly Guid _userId;

        public MealService(ApplicationDbContext context, Guid userId)
        {
            _context = context;
            _userId = userId;
        }

        //public IEnumerable<MealListItem> GetMeals()
        //{

        //}

        //public MealDetail GetMealById(int id)
        //{

        //}

        //public bool CreateMeal(MealCreate model)
        //{

        //}

        //public bool UpdateMeal(MealEdit model)
        //{

        //}

        //public bool DeleteMeal(int id)
        //{

        //}
    }
}
