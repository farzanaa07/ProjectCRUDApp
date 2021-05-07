using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Data;
using ProjectAppLibrary.Models;
using ProjectAppLibrary.Models.Binding;
using ProjectAppLibrary.Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;


        public FoodsController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        [HttpGet("")] //retrieves information
        public IActionResult GetAllFoods()
        {
            var allFoods = dbContext.Foods.ToList();
            return Ok(allFoods.GetViewModels());
        }
        [HttpGet("{id:int}")] //because there is more than one of the same HttpGet, route needs to be specified
        public IActionResult GetfoodById(int id)
        {
            var foodbyID = dbContext.Foods.FirstOrDefault(r => r.ID == id); //
            if (foodbyID == null) //if food ID not found, return NotFound but if it is found then return Ok result
                return NotFound();
            return Ok(foodbyID.GetViewModel());
        }
        [HttpPost("")] //doesnt need to take anything in because it is different to HttpGet
        public IActionResult Create([FromBody] AddFoodBindingModel bindingModel) //need to pass information from the body of the request
        {
            var FoodToCreate = new Food
            {
                Name = bindingModel.Name,
                Cuisine = bindingModel.Cuisine,
                Description = bindingModel.Description,
                PictureURL = "https://theresident.wpms.greatbritishlife.co.uk/wp-content/uploads/sites/10/2020/07/Le-Pont-de-la-tour-Terrace-.jpg", //this will give you a default picture
                CreatedAt = DateTime.Now
            };
            var createdfood = dbContext.Foods.Add(FoodToCreate).Entity; //adds the food created to the database and get the entire state of the food
            dbContext.SaveChanges(); //saves the changes
            return Ok(FoodToCreate.GetViewModel());

        }
        [HttpPut("{id:int}")] //modifies information by ID
        public IActionResult Updatefood([FromBody] Food food, int id) //gets the food object from body of request
        {
            var foodbyId = dbContext.Foods.FirstOrDefault(r => r.ID == id); //allows you to find the food ID of the food you want to update
            if (foodbyId == null)
                return NotFound();
            foodbyId.Name = food.Name;
            foodbyId.Cuisine = food.Cuisine;
            foodbyId.Description = food.Description;
            foodbyId.PictureURL = food.PictureURL;
           
            dbContext.SaveChanges(); //saves the updated changes

            return Ok(foodbyId.GetViewModel());
        }

        [HttpDelete("{id:int}")] //deletes the food by its ID
        public IActionResult Deletefood(int id)
        {
            var foodToDelete = dbContext.Foods.FirstOrDefault(r => r.ID == id);
            if (foodToDelete == null) //if food ID not found, return NotFound
                return NotFound();
            dbContext.Foods.Remove(foodToDelete); //will remove food from database
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
