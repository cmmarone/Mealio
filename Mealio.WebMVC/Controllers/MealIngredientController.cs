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
    public class MealIngredientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealIngredientController(ApplicationDbContext context)
        {
            _context = context;
        }


        // MealIngredient/Create(GET)

        
        // MealIngredient/Create(POST)
        
       
        // MealIngredient/Edit/{id} (GET)
        
        
        // MealIngredient/Edit/{id} (POST)

        private MealIngredientService CreateMealIngredientServive()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            return new MealIngredientService(_context, userId);
        }
    }
}
