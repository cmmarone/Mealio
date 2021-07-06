using Mealio.Data;
using Mealio.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mealio.WebMVC.Controllers
{
    public class IngredientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Ingredient (GET)
        public IActionResult Index()
        {
            var service = CreateIngredientService();
            var modelList = service.GetIngredients();
            return View(modelList);
        }

        
        // Ingredient/Edit/{id} (GET)
        // Ingredient/Edit/{id} (POST)
        // Ingredient/Delete/{id} (GET)
        // Ingredient/DeletePost/{id} (POST)

        private IngredientService CreateIngredientService()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            return new IngredientService(_context, userId);
        }
    }
}
