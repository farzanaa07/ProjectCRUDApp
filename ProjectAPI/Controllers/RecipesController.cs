using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Data;
using ProjectAppLibrary;
using ProjectAppLibrary.Models.Binding;
using ProjectAppLibrary.Models.Utility;
using ProjectAppLibrary.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;


        public RecipesController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        [HttpGet("")] //retrieves information
        public IActionResult GetAllRecipes()
        {
            var allRecipes = dbContext.Recipes.ToList(); 
            return Ok(allRecipes.GetViewModels());
        }
        [HttpGet("{id:int}")] //because there is more than one of the same HttpGet, route needs to be specified
        public IActionResult GetrecipeById(int id)
        {
            var recipebyID = dbContext.Recipes.FirstOrDefault(r => r.ID == id); //
            if (recipebyID == null) //if recipe ID not found, return NotFound but if it is found then return Ok result
                return NotFound();
            return Ok(recipebyID.GetViewModel());
        }     
        [HttpPost("")] //doesnt need to take anything in because it is different to HttpGet
        public IActionResult Create([FromBody] AddRecipeBindingModel bindingModel) //need to pass information from the body of the request
        {
            var RecipeToCreate = new Recipe
            {
                RecipeName = bindingModel.RecipeName,
                Ingredients = bindingModel.Ingredients,
                Method = bindingModel.Method,
                Food = dbContext.Foods.FirstOrDefault(r => r.ID == bindingModel.FoodID),
                PictureURL = "https://theresident.wpms.greatbritishlife.co.uk/wp-content/uploads/sites/10/2020/07/Le-Pont-de-la-tour-Terrace-.jpg", //this will give you a default picture
                LevelofDifficulty = bindingModel.LevelofDifficulty,
                CreatedAt = DateTime.Now
            };
            var createdrecipe = dbContext.Recipes.Add(RecipeToCreate).Entity; //adds the recipe created to the database and get the entire state of the Recipe
           dbContext.SaveChanges(); //saves the changes
            return Ok(RecipeToCreate.GetViewModel());
           
        }
        [HttpPut("{id:int}")] //modifies information by ID
        public IActionResult Updaterecipe([FromBody] Recipe recipe, int id) //gets the recipe object from body of request
        {
            var recipebyId = dbContext.Recipes.FirstOrDefault(r => r.ID == id); //allows you to find the recipe ID of the recipe you want to update
            if (recipebyId == null)
                return NotFound();
                recipebyId.RecipeName = recipe.RecipeName;
                recipebyId.Ingredients = recipe.Ingredients;
                recipebyId.Method = recipe.Method;
                recipebyId.PictureURL = recipe.PictureURL;
                recipebyId.LevelofDifficulty = recipe.LevelofDifficulty;
            dbContext.SaveChanges(); //saves the updated changes
          
            return Ok(recipebyId.GetViewModel());
        }

        [HttpDelete("{id:int}")] //deletes the recipe by its ID
        public IActionResult Deleterecipe(int id)
        {
            var recipeToDelete = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            if (recipeToDelete == null) //if recipe ID not found, return NotFound
                return NotFound();
            dbContext.Recipes.Remove(recipeToDelete); //will remove recipe from database
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
