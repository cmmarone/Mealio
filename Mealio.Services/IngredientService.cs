using Mealio.Data;
using Mealio.Models.IngredientModels;
using Mealio.Models.MealModels;
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

        //public bool CreateIngredient(MealCreate model)
        //{

        //}

        //public bool UpdateIngredient(IngredientEdit model)
        //{

        //}

        //public bool DeleteIngredient(int id)
        //{

        //}

    }
}
