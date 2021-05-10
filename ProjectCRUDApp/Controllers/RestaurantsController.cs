using Microsoft.AspNetCore.Mvc;
using ProjectAppLibrary.Models;
using ProjectAppLibrary.Models.Binding;
using ProjectCRUDApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUDApp.Controllers
{
    [Route("[Controller]")]
    public class RestaurantController : Controller
    {
        private IRepositoryWrapper repository;
        public RestaurantController(IRepositoryWrapper repositoryWrapper)
        {
            repository = repositoryWrapper;

        }


        //READ
        [Route("")]
        public IActionResult Index()
        {
            var allRestaurants = repository.Restaurant.FindAll(); //will show all restaurants on the list
            return View(allRestaurants);
        }
        [Route("details/{id:int}")] //specify the route by using a placeholder which maps directly what you put in (by recognising the restaurant by its ID)
        public IActionResult Details(int id)
        {
            var RestaurantbyID = repository.Restaurant.FindByCondition(r => r.ID == id).FirstOrDefault(); //Find the cat by its ID in the database
            return View(RestaurantbyID);
        }
        

        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id) //find restaurant and populate the form on this page
        {
            var RestaurantbyID = repository.Restaurant.FindByCondition(r => r.ID == id).FirstOrDefault(); //Find the restaurant by its ID in the database
            return View(RestaurantbyID);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(Restaurant restaurant, int id) //pass in ID of restaurant
        {
            repository.Restaurant.Update(restaurant);
            repository.Save(); //saves the updated changes
            return RedirectToAction("Index"); //will return page to the index
        }


        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var RestaurantToDelete = repository.Restaurant.FindByCondition(r => r.FoodID == id).FirstOrDefault();
            repository.Restaurant.Delete(RestaurantToDelete); //will remove restaurant from database
            repository.Save();
            return RedirectToAction("Index");
        }
    }
}
