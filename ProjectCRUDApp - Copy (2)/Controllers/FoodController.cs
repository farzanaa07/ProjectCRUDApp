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
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext dbContext; //injection dependency
        public FoodController(ApplicationDbContext applicationDbContext)
        {

            dbContext = applicationDbContext;
        }

    

        //READ
        [Route("")]
        public IActionResult Index()
        {
            var allfoods = dbContext.Foods.ToList(); //will show all foods on the list
            return View(allfoods);
        }
        [Route("details/{id:int}")] //specify the route by using a placeholder which maps directly what you put in (by recognising the food by its ID)
        public IActionResult Details(int id)
        {
            var foodbyID = dbContext.Foods.FirstOrDefault(r => r.ID == id); //Find the cat by its ID in the database
            return View(foodbyID);
        }



        //CREATE
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")] //sends data into a partcular place.
        public IActionResult Create(AddFoodBindingModel bindingModel)
        {
            var foodToCreate = new Food
            {
                Name = bindingModel.Name,
                Cuisine = bindingModel.Cuisine,
                Description = bindingModel.Description,
                PictureURL = "https://theresident.wpms.greatbritishlife.co.uk/wp-content/uploads/sites/10/2020/07/Le-Pont-de-la-tour-Terrace-.jpg", //this will give you a default picture
             CreatedAt = DateTime.Now
            };

            dbContext.Foods.Add(foodToCreate); //adds the food created to the database
            dbContext.SaveChanges(); //saves the changes
            return RedirectToAction("Index"); //will return page to index
        }

       
      
        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id) //find food and populate the form on this page
        {
            var foodbyID = dbContext.Foods.FirstOrDefault(r => r.ID == id); //Find the cat by its ID in the database
            return View(foodbyID);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(Food food, int id) //pass in ID of food
        {
            var foodToUpdate = dbContext.Foods.FirstOrDefault(r => r.ID == id); //allows you to find the food ID of the food you want to update
            {
                foodToUpdate.Name = food.Name;
                foodToUpdate.Cuisine = food.Cuisine;
                foodToUpdate.Description = food.Description;
                foodToUpdate.PictureURL = food.PictureURL;
              

            };
            dbContext.SaveChanges(); //saves the updated changes
            return RedirectToAction("Index"); //will return page to the index
        }


        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var foodToDelete = dbContext.Foods.FirstOrDefault(r => r.ID == id);
            dbContext.Foods.Remove(foodToDelete); //will remove food from database
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }




        // RESTAURANT
        [Route("addrestaurant/{foodid:int}")]
        public IActionResult CreateRestaurant(int foodID)
        {
            var food = dbContext.Foods.FirstOrDefault(r => r.ID == foodID);
            ViewBag.foodName = food.Name;
            return View();
        }
        [HttpPost] //sends data into a particular place.
        [Route("addrestaurant/{foodid:int}")]
        public IActionResult CreateRestaurant(AddRestaurantBindingModel bindingModel, int foodID)
        {
            bindingModel.FoodID = foodID;
            var RestaurantToCreate = new Restaurant
            {
                Name = bindingModel.Name,
                Location = bindingModel.Location,
                NameofDish = bindingModel.NameofDish,
                Delivery = bindingModel.Delivery,
                Food = dbContext.Foods.FirstOrDefault(r => r.ID == bindingModel.FoodID),
                PictureURL = "https://static01.nyt.com/images/2021/01/26/well/well-foods-microbiome/well-foods-microbiome-mobileMasterAt3x.jpg", //default picture
                ratings = bindingModel.ratings,
                CreatedAt = DateTime.Now
            };

            dbContext.Restaurants.Add(RestaurantToCreate); //adds the food created to the database
            dbContext.SaveChanges(); //saves the changes
            return RedirectToAction("Index"); //will return page to index
        }


        [Route("{id:int}/restaurant")]
        public IActionResult ViewRestaurants(int id)
        {
            var food = dbContext.Foods.FirstOrDefault(r => r.ID == id);
            var restaurant= dbContext.Restaurants.Where(r => r.Food.ID == id).ToList();
            ViewBag.foodName = food.Name;
            return View(restaurant);
        }


        // RECIPE
        [Route("addrecipe/{foodid:int}")]
        public IActionResult CreateRecipe(int foodID)
        {
            var food = dbContext.Foods.FirstOrDefault(r => r.ID == foodID);
            ViewBag.foodName = food.Name;
            return View();
        }
        [HttpPost] //sends data into a particular place.
        [Route("addrecipe/{foodid:int}")]
        public IActionResult CreateRecipe(AddRecipeBindingModel bindingModel, int foodID)
        {
            bindingModel.FoodID = foodID;
            var RecipeToCreate = new Recipe
            {
                RecipeName = bindingModel.RecipeName,
                Ingredients = bindingModel.Ingredients,
                Method = bindingModel.Method,
                Servings=bindingModel.Servings,
                Food = dbContext.Foods.FirstOrDefault(r => r.ID == bindingModel.FoodID),
                PictureURL = "https://static01.nyt.com/images/2021/01/26/well/well-foods-microbiome/well-foods-microbiome-mobileMasterAt3x.jpg", //default picture
                LevelofDifficulty = bindingModel.LevelofDifficulty,
                CreatedAt = DateTime.Now
            };

            dbContext.Recipes.Add(RecipeToCreate); //adds the food created to the database
            dbContext.SaveChanges(); //saves the changes
            return RedirectToAction("Index"); //will return page to index
        }
        [Route("{id:int}/recipe")]
        public IActionResult ViewRecipes(int id)
        {
            var food = dbContext.Foods.FirstOrDefault(r =>r.ID == id);
            var recipes = dbContext.Recipes.Where(r => r.Food.ID == id).ToList();
            ViewBag.foodName = food.Name;
            return View(recipes);
        }


    }
}
