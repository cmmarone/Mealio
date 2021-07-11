using Mealio.Data;
using Mealio.Data.Entities;
using Mealio.Models.MealModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<MealListItem> GetMeals()
        {
            var mealModels = _context.Meals
                .Where(m => m.UserId == _userId)
                .Select(i => new MealListItem
                {
                    Id = i.Id,
                    Name = i.Name,
                    MealType = i.MealType,
                    MealPlan = (i.MealPlanId == 0) ? "Not on a plan" : i.MealPlan.Name
                }).ToList().OrderBy(m => m.Name);
            return mealModels;
        }

        public MealDetail GetMealById(int id)
        {
            var mealEntity = _context.Meals.FirstOrDefault(m => m.Id == id && m.UserId == _userId);

            string mealPlan;
            string planDay;
            if (mealEntity.MealPlanId == 0)
            {
                mealPlan = "Not on a plan";
                planDay = "N/A";
            }
            else
            {
                mealPlan = mealEntity.MealPlan.Name;

                int dayMod = (mealEntity.PlanDayIndex + 6) % 7;
                string dayOfWeek = (mealEntity.MealPlan.StartDate.DayOfWeek + dayMod).ToString();
                string weekNum = ((mealEntity.PlanDayIndex + 6) / 7).ToString();
                planDay = $"{dayOfWeek}, Week {weekNum}";
            }

            var mealIngredients = new List<string>();
            foreach(var mealIngredient in mealEntity.MealIngredients)
            {
                string ingredient = 
                    $"{mealIngredient.Amount} " +
                    $"{mealIngredient.Ingredient.Units} " +
                    $"{mealIngredient.Ingredient.Name}";
                mealIngredients.Add(ingredient);
            }

            return new MealDetail()
            {
                Id = mealEntity.Id,
                Name = mealEntity.Name,
                MealType = mealEntity.MealType,
                MealPlan = mealPlan,
                PlanDay = planDay,
                CookingInstructions = mealEntity.CookingInstructions,
                MealIngredients = mealIngredients
            };
        }

        public bool CreateMeal(MealCreate model)
        {
            var mealPlan = _context.MealPlans.FirstOrDefault(mp =>
                mp.Name.ToLower() == model.MealPlan.ToLower() &&
                mp.UserId == _userId);
            var mealPlanId = (mealPlan != null) ? mealPlan.Id : 0;

            var meal = new Meal()
            {
                Name = model.Name,
                MealType = model.MealType,
                MealPlanId = mealPlanId,
                PlanDayIndex = model.PlanDayIndex,
                UserId = _userId
            };
            _context.Add(meal);
            return _context.SaveChanges() == 1;
        }

        public bool UpdateMeal(MealEdit model)
        {
            var mealEntity = _context.Meals.FirstOrDefault(m => m.Id == model.Id && m.UserId == _userId);

            mealEntity.Name = model.Name;
            mealEntity.MealType = model.MealType;
            mealEntity.CookingInstructions = model.CookingInstructions;
            mealEntity.MealPlanId = 
                (_context.MealPlans.FirstOrDefault(mp => 
                mp.Name.ToLower() == model.MealPlan.ToLower() &&
                mp.UserId == _userId)).Id;
            mealEntity.PlanDayIndex = model.PlanDayIndex;
            return _context.SaveChanges() == 1;
        }

        public bool DeleteMeal(int id)
        {
            var mealEntity = _context.Meals.FirstOrDefault(m => m.Id == id && m.UserId == _userId);

            _context.Meals.Remove(mealEntity);
            return _context.SaveChanges() == 1;
        }
    }
}
