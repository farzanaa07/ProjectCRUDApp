using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class RestaurantsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;


        public RestaurantsController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        [HttpGet("")] //retrieves information
        public IActionResult GetAllRestaurants()
        {
            var allrestaurants = dbContext.Restaurants.ToList();
            return Ok(allrestaurants.GetViewModels());
        }
        [HttpGet("{id:int}")] //because there is more than one of the same HttpGet, route needs to be specified
        public IActionResult GetRestaurantById(int id)
        {
            var RestaurantbyID = dbContext.Restaurants.FirstOrDefault(r => r.ID == id); //
            if (RestaurantbyID == null) //if restaurant ID not found, return NotFound but if it is found then return Ok result
                return NotFound();
            return Ok(RestaurantbyID.GetViewModel());
        }
        [HttpPost("")] //doesnt need to take anything in because it is different to HttpGet
        public IActionResult Create([FromBody] AddRestaurantBindingModel bindingModel) //need to pass information from the body of the request
        {
            var RestaurantToCreate = new Restaurant
            {
                Name = bindingModel.Name,
                Location = bindingModel.Location,
                NameofDish = bindingModel.NameofDish,
                Food = dbContext.Foods.FirstOrDefault(r => r.ID == bindingModel.FoodID),
                PictureURL = "https://theresident.wpms.greatbritishlife.co.uk/wp-content/uploads/sites/10/2020/07/Le-Pont-de-la-tour-Terrace-.jpg", //this will give you a default picture
                Delivery = bindingModel.Delivery,
                ratings = bindingModel.ratings,
                CreatedAt = DateTime.Now
            };
            var createdrestaurant = dbContext.Restaurants.Add(RestaurantToCreate).Entity; //adds the recipe created to the database and get the entire state of the restaurants
            dbContext.SaveChanges(); //saves the changes
            return Ok(createdrestaurant.GetViewModel()); //returns the entity from that database when you try to add to the database
          //create an errors page 37mins

        }
            [HttpPut("{id:int}")] //modifies information by ID
            public IActionResult UpdateRestaurant([FromBody]Restaurant restaurant, int id) //gets the restaurant object from body of request
            {
                var RestaurantbyId = dbContext.Restaurants.FirstOrDefault(r => r.ID == id); //allows you to find the restaurant ID of the restaurant you want to update
                {
                RestaurantbyId.Name = restaurant.Name;
                RestaurantbyId.Location = restaurant.Location;
                RestaurantbyId.NameofDish = restaurant.NameofDish;
                RestaurantbyId.PictureURL = restaurant.PictureURL;
                RestaurantbyId.Delivery = restaurant.Delivery;
                RestaurantbyId.ratings = restaurant.ratings;


                };
                dbContext.SaveChanges(); //saves the updated changes
                return Ok(RestaurantbyId.GetViewModel()); //will return page to the index
            }

        [HttpDelete ("{id:int}")] //deletes the restaurant by its ID
        public IActionResult DeleteRestaurant(int id)
        {
            var RestaurantToDelete = dbContext.Restaurants.FirstOrDefault(r => r.ID == id);
            if (RestaurantToDelete == null) //if restaurant ID not found, return NotFound
                return NotFound();
            dbContext.Restaurants.Remove(RestaurantToDelete); //will remove restaurant from database
            dbContext.SaveChanges();
            return NoContent();
        }
    }
        }

