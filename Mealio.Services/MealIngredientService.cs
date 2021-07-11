using Mealio.Data;
using Mealio.Data.Entities;
using Mealio.Models.MealIngredientModels;
using Mealio.Models.MealModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public bool CreateMealIngredient(MealIngredientCreate model)
        {
            if (!_context.Ingredients.Any(i => i.Name == model.IngredientName))
            {
                var ingredientService = CreateIngredientService();
                if (!ingredientService.CreateIngredient(model))
                    return false;
            }
            var mealIngredient = new MealIngredient()
            {
                MealId = (_context.Meals.FirstOrDefault(m => m.Name == model.MealName)).Id,
                IngredientId = (_context.Ingredients.FirstOrDefault(i => i.Name == model.IngredientName)).Id,
                Amount = model.Amount
            };
            _context.MealIngredients.Add(mealIngredient);
            return _context.SaveChanges() == 1;
        }

        public bool UpdateMealIngredient(MealIngredientEdit model)
        {
            if (!_context.Ingredients.Any(i => i.Name == model.IngredientName))
            {
                var mealIngredientCreateModel = new MealIngredientCreate()
                {
                    IngredientName = model.IngredientName,
                    Units = model.Units
                };
                var ingredientService = CreateIngredientService();
                if (!ingredientService.CreateIngredient(mealIngredientCreateModel))
                    return false;
            }

            var mealIngredientEntity = _context.MealIngredients
                .FirstOrDefault(mi => mi.Id == model.Id && mi.UserId == _userId);

            mealIngredientEntity.IngredientId = (_context.Ingredients
                .FirstOrDefault(i => i.Name == model.IngredientName)).Id;
            mealIngredientEntity.Amount = model.Amount;
            return _context.SaveChanges() == 1;
        }

        //public bool DeleteMealIngredient(int id)
        //{

        //}

        private IngredientService CreateIngredientService()
        {
            return new IngredientService(_context, _userId);
        }
    }
}
