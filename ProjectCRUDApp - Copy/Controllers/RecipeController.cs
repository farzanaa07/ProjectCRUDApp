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



        //CREATE
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")] //sends data into a partcular place.
        public IActionResult Create(AddRecipeBindingModel bindingModel)
        {
            var RecipeToCreate = new Recipe
            {
                RecipeName = bindingModel.RecipeName,
                Ingredients = bindingModel.Ingredients,
                Method = bindingModel.Method,
                PictureURL = "https://theresident.wpms.greatbritishlife.co.uk/wp-content/uploads/sites/10/2020/07/Le-Pont-de-la-tour-Terrace-.jpg", //this will give you a default picture
                LevelofDifficulty = bindingModel.LevelofDifficulty,
                CreatedAt = DateTime.Now
            };

            dbContext.Recipes.Add(RecipeToCreate); //adds the recipe created to the database
            dbContext.SaveChanges(); //saves the changes
            return RedirectToAction("Index"); //will return page to index
        }

        //CREATE    RESTAURANT
        [Route("addrestaurant/{recipeid:int}")] 
        public IActionResult CreateRestaurant(int RecipeID)
        {
            var recipe = dbContext.Recipes.FirstOrDefault(r => r.ID == RecipeID);
            ViewBag.RecipeName = recipe.RecipeName;
            return View();
        }
        [HttpPost] //sends data into a partcular place.
        [Route("addrestaurant/{recipeid:int}")]
        public IActionResult CreateRestaurant(AddRestaurantBindingModel bindingModel, int RecipeID)
        {
            bindingModel.RecipeID = RecipeID;
            var RestaurantToCreate = new Restaurant
            {
                Name = bindingModel.Name,
                Location = bindingModel.Location,
                NameofDish = bindingModel.NameofDish,
                Delivery = bindingModel.Delivery,
                Recipe =dbContext.Recipes.FirstOrDefault(r=>r.ID==bindingModel.RecipeID),
                PictureURL = "https://static01.nyt.com/images/2021/01/26/well/well-foods-microbiome/well-foods-microbiome-mobileMasterAt3x.jpg", //default picture
                ratings = bindingModel.ratings,
                CreatedAt = DateTime.Now
            };

            dbContext.Restaurants.Add(RestaurantToCreate); //adds the recipe created to the database
            dbContext.SaveChanges(); //saves the changes
            return RedirectToAction("Index"); //will return page to index
        }

        [Route("{id:int}/restaurant")]
        public IActionResult ViewRestaurants(int id)
        {
            var recipe = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            var restaurant = dbContext.Restaurants.Where(r => r.Recipe.ID == id).ToList();
            ViewBag.RecipeName = recipe.RecipeName;
            return View(restaurant);
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
