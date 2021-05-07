using Microsoft.AspNetCore.Mvc;
using ProjectAppLibrary;
using ProjectAppLibrary.Models;
using ProjectAppLibrary.Models.Binding;
using ProjectCRUDApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingLibrary.Testing.InterfaceTesting;

namespace ProjectCRUDApp.Controllers
{
    [Route("[Controller]")] //a route property with placeholder
    public class FoodController : Controller
    {
        private IRepositoryWrapper repository;
        public FoodController(IRepositoryWrapper repositoryWrapper)
        {
            repository = repositoryWrapper;

        }

        //READ
        [Route("")]
        public IActionResult Index()
        {
            var allfoods = repository.Food.FindAll();
           // var allfoods = dbContext.Foods.ToList(); //will show all foods on the list
            return View(allfoods);
        }
        [Route("details/{id:int}")] //specify the route by using a placeholder which maps directly what you put in (by recognising the food by its ID)
        public IActionResult Details(int id)
        {
            var foodbyID=repository.Food.FindByCondition(r => r.ID == id).FirstOrDefault(); //using the repository created to access the DbContext in the testing library
           // var foodbyID = dbContext.Foods.FirstOrDefault(r => r.ID == id); //Find the cat by its ID in the database
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
            repository.Food.Create(foodToCreate);
            repository.Save();
            return RedirectToAction("Index"); //will return page to index
        }

       
      
        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id) //find food and populate the form on this page
        {
             var foodbyID=repository.Food.FindByCondition(r => r.ID == id).FirstOrDefault();
              return View(foodbyID);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(Food food, int id) //pass in ID of food
        { 
            repository.Food.Update(food);
            repository.Save();
            return RedirectToAction("Index"); //will return page to the index
        }


        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var recipesToDelete = repository.Recipe.FindByCondition(r => r.FoodID == id);
            foreach (var recipe in recipesToDelete)
            { repository.Recipe.Delete(recipe); }
            repository.Save();
            var restaurantsToDelete = repository.Restaurant.FindByCondition(r => r.FoodID == id);
            foreach (var restaurant in restaurantsToDelete)
            { repository.Restaurant.Delete(restaurant); }
            repository.Save();
            var foodToDelete = repository.Food.FindByCondition(r => r.ID == id).FirstOrDefault();
            repository.Food.Delete(foodToDelete); //will remove food from database
            repository.Save();
            return RedirectToAction("Index");
        }




        // RESTAURANT
        [Route("addrestaurant/{foodid:int}")]
        public IActionResult CreateRestaurant(int foodID)
        {
            var food = repository.Food.FindByCondition(r => r.ID == foodID).FirstOrDefault();
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
                FoodID = bindingModel.FoodID,
                PictureURL = "https://static01.nyt.com/images/2021/01/26/well/well-foods-microbiome/well-foods-microbiome-mobileMasterAt3x.jpg", //default picture
                ratings = bindingModel.ratings,
                CreatedAt = DateTime.Now
            };

            repository.Restaurant.Create(RestaurantToCreate); //adds the restaurant created to the database
            repository.Save(); //saves the changes
            return RedirectToAction("Index"); //will return page to index
        }

       
        [Route("{id:int}/restaurant")]
        public IActionResult ViewRestaurants(int id)
        {
            var food = repository.Food.FindByCondition(r => r.ID == id).FirstOrDefault();
           var restaurant= repository.Restaurant.FindByCondition(r => r.Food.ID == id).ToList();
            ViewBag.foodName = food.Name;
            return View(restaurant);
        }


        // RECIPE
        [Route("addrecipe/{foodid:int}")]
        public IActionResult CreateRecipe(int foodID)
        {
            var food = repository.Food.FindByCondition(r => r.ID == foodID).FirstOrDefault();
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
                Servings = bindingModel.Servings,
                FoodID = bindingModel.FoodID,
                PictureURL = "https://static01.nyt.com/images/2021/01/26/well/well-foods-microbiome/well-foods-microbiome-mobileMasterAt3x.jpg", //default picture
                LevelofDifficulty = bindingModel.LevelofDifficulty,
                CreatedAt = DateTime.Now
            };

            repository.Recipe.Create(RecipeToCreate); //adds the food created to the database
            repository.Save();//saves the changes
            return RedirectToAction("Index"); //will return page to index
        }
        [Route("{id:int}/recipe")]
        public IActionResult ViewRecipes(int id)
        {
            var food = repository.Food.FindByCondition(r =>r.ID == id).FirstOrDefault();
            var recipe = repository.Recipe.FindByCondition(r => r.Food.ID == id).ToList();
            ViewBag.foodName = food.Name;
            return View(recipe);
        }


    }
}
