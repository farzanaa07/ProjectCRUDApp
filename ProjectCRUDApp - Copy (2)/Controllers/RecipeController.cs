using Microsoft.AspNetCore.Mvc;
using ProjectAppLibrary;
using ProjectAppLibrary.Models;
using ProjectAppLibrary.Models.Binding;
using ProjectCRUDApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUDApp.Controllers
{
    [Route("[Controller]")] //a route property with placeholder
        public class RecipeController : Controller
    {
        private readonly ApplicationDbContext dbContext; //injection dependency
    public RecipeController(ApplicationDbContext applicationDbContext)
    {

        dbContext = applicationDbContext;
    }

        //READ
        [Route("")]
        public IActionResult Index()
        {
            var allRecipes = dbContext.Recipes.ToList(); //will show all recipes on the list
            return View(allRecipes);
        }
        [Route("details/{id:int}")] //specify the route by using a placeholder which maps directly what you put in (by recognising the recipe by its ID)
        public IActionResult Details(int id)
        {
            var RecipebyID = dbContext.Recipes.FirstOrDefault(r => r.ID == id); //Find the cat by its ID in the database
            return View(RecipebyID);
        }

        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id) //find recipe and populate the form on this page
            {
            var RecipebyID = dbContext.Recipes.FirstOrDefault(r => r.ID == id); //Find the cat by its ID in the database
            return View(RecipebyID);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(Recipe recipe, int id) //pass in ID of recipe
        {
            var RecipeToUpdate = dbContext.Recipes.FirstOrDefault(r => r.ID == id); //allows you to find the recipe ID of the recipe you want to update
            {
            RecipeToUpdate.RecipeName = recipe.RecipeName;
            RecipeToUpdate.Ingredients = recipe.Ingredients;
            RecipeToUpdate.Method = recipe.Method;
             RecipeToUpdate.Servings = recipe.Servings;
            RecipeToUpdate.PictureURL = recipe.PictureURL;
            RecipeToUpdate.LevelofDifficulty = recipe.LevelofDifficulty;
          
            };
            dbContext.SaveChanges(); //saves the updated changes
            return RedirectToAction("Index"); //will return page to the index
        }


        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var RecipeToDelete = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            dbContext.Recipes.Remove(RecipeToDelete); //will remove recipe from database
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
