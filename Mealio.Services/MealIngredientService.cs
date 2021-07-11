using Mealio.Data;
using Mealio.Models.MealModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mealio.Services
{
    public class MealIngredientService
    {
        private readonly ApplicationDbContext _context;
        private readonly Guid _userId;

        public MealIngredientService(ApplicationDbContext context, Guid userId)
        {
            _context = context;
            _userId = userId;
        }

        //public bool CreateMealIngredient(MealIngredientCreate model)
        //{

        //}

        //public bool UpdateMealIngredient(MealEdit model)
        //{

        //}

        //public bool DeleteMealIngredient(int id)
        //{

        //}
    }
}
