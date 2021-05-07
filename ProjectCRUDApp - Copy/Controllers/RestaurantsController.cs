using Microsoft.AspNetCore.Mvc;
using ProjectAppLibrary.Models;
using ProjectAppLibrary.Models.Binding;
using ProjectCRUDApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUDApp.Controllers
{
    [Route("[Controller]")]
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext dbContext; //injection dependency
        public RestaurantController(ApplicationDbContext applicationDbContext)
        {

            dbContext = applicationDbContext;
        }

        //READ
        [Route("")]
        public IActionResult Index()
        {
            var allRestaurants = dbContext.Restaurants.ToList(); //will show all restaurants on the list
            return View(allRestaurants);
        }
        [Route("details/{id:int}")] //specify the route by using a placeholder which maps directly what you put in (by recognising the restaurant by its ID)
        public IActionResult Details(int id)
        {
            var RestaurantbyID = dbContext.Restaurants.FirstOrDefault(r => r.ID == id); //Find the cat by its ID in the database
            return View(RestaurantbyID);
        }
        

        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id) //find restaurant and populate the form on this page
        {
            var RestaurantbyID = dbContext.Restaurants.FirstOrDefault(r => r.ID == id); //Find the restaurant by its ID in the database
            return View(RestaurantbyID);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(Restaurant restaurant, int id) //pass in ID of restaurant
        {
            var RestaurantToUpdate = dbContext.Restaurants.FirstOrDefault(r => r.ID == id); //allows you to find the restaurant ID of the restaurant you want to update
            {
                RestaurantToUpdate.Name = restaurant.Name;
                RestaurantToUpdate.Location = restaurant.Location;
                RestaurantToUpdate.NameofDish = restaurant.NameofDish;
                RestaurantToUpdate.PictureURL = restaurant.PictureURL;
                RestaurantToUpdate.Delivery = restaurant.Delivery;
                RestaurantToUpdate.ratings = restaurant.ratings;


            };
            dbContext.SaveChanges(); //saves the updated changes
            return RedirectToAction("Index"); //will return page to the index
        }


        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var RestaurantToDelete = dbContext.Restaurants.FirstOrDefault(r => r.ID == id);
            dbContext.Restaurants.Remove(RestaurantToDelete); //will remove restaurant from database
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
