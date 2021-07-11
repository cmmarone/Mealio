using Mealio.Data;
using Mealio.Data.Entities;
using Mealio.Models.IngredientModels;
using Mealio.Models.MealIngredientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mealio.Services
{
    public class IngredientService
    {
        private readonly ApplicationDbContext _context;
        private readonly Guid _userId;

        public IngredientService(ApplicationDbContext context, Guid userId)
        {
            _context = context;
            _userId = userId;
        }

        public IEnumerable<IngredientListItem> GetIngredients()
        {
            var ingredientModels = _context.Ingredients
                .Where(i => i.UserId == _userId)
                .Select(i => new IngredientListItem
                {
                    Id = i.Id,
                    Name = i.Name,
                    Units = i.Units
                }).ToList().OrderBy(m => m.Name);
            return ingredientModels;
        }

        public bool CreateIngredient(MealIngredientCreate model)
        {
            if (_context.Ingredients.Any(i => i.Name.ToLower() == model.Ingredient.ToLower()))
                return true;

            var ingredient = new Ingredient()
            {
                Name = model.Ingredient,
                Units = model.Units,
                UserId = _userId
            };
            _context.Ingredients.Add(ingredient);
            return _context.SaveChanges() == 1;
        }

        public bool UpdateIngredient(IngredientEdit model)
        {
            var ingredientEntity = _context.Ingredients.FirstOrDefault(i => i.Id == model.Id && i.UserId == _userId);

            ingredientEntity.Name = model.Name;
            ingredientEntity.Units = model.Units;
            return _context.SaveChanges() == 1;
        }

        public bool DeleteIngredient(int id)
        {
            var ingredientEntity = _context.Ingredients.FirstOrDefault(i => i.Id == id && i.UserId == _userId);

            _context.Ingredients.Remove(ingredientEntity);
            return _context.SaveChanges() == 1;
        }
    }
}
