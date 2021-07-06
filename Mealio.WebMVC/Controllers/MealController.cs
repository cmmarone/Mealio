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
    public class MealController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Meal/Index (GET)


        // Meal/Details/{id} (GET)


        // Meal/Create (GET)


        // Meal/Create (POST)


        // Meal/Edit/{id} (GET)


        // Meal/Edit/{id} (POST)


        // Meal/Delete/{id} (GET)


        // Meal/DeletePost/{id} (POST)

        private MealService CreateMealServive()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            return new MealService(_context, userId);
        }
    }
}
