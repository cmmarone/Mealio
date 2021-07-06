using Mealio.Data;
using Mealio.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mealio.WebMVC.Controllers
{
    public class MealPlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealPlanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // MealPlan/Index (GET)


        // MealPlan/Details/{id} (GET)


        // MealPlan/Create (GET)


        // MealPlan/Create (POST)


        // MealPlan/Edit/{id} (GET)


        // MealPlan/Edit/{id} (POST)


        // MealPlan/Delete/{id} (GET)


        // MealPlan/DeletePost/{id} (POST)


        private MealPlanService CreateMealPlanServive()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            return new MealPlanService(_context, userId);
        }
    }
}
