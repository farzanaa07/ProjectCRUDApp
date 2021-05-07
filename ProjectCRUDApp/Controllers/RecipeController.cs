using Microsoft.AspNetCore.Mvc;
using ProjectAppLibrary;
using ProjectAppLibrary.Models;
using ProjectAppLibrary.Models.Binding;
using ProjectCRUDApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUDApp.Controllers
{
    [Route("[Controller]")] //a route property with placeholder
    public class RecipeController : Controller
    { 
    private IRepositoryWrapper repository;
    public RecipeController(IRepositoryWrapper repositoryWrapper)
    {
        repository = repositoryWrapper;

    }

    //READ
    [Route("")]
        public IActionResult Index()
        {
            var allRecipes = repository.Recipe.FindAll(); //will show all recipes on the list
            return View(allRecipes);
        }
        [Route("details/{id:int}")] //specify the route by using a placeholder which maps directly what you put in (by recognising the recipe by its ID)
        public IActionResult Details(int id)
        {
            var RecipebyID = repository.Recipe.FindByCondition(r => r.ID == id).FirstOrDefault(); //Find the recipe by its ID in the database
            return View(RecipebyID);
        }

        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id) //find recipe and populate the form on this page
            {
            var RecipebyID = repository.Recipe.FindByCondition(r => r.ID == id).FirstOrDefault(); //Find the cat by its ID in the database
            return View(RecipebyID);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(Recipe recipe, int id) //pass in ID of recipe
        {
            repository.Recipe.Update(recipe);
            repository.Save(); //saves the updated changes
            return RedirectToAction("Index"); //will return page to the index
        }


        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var RecipeToDelete = repository.Recipe.FindByCondition(r => r.ID == id).FirstOrDefault();
            repository.Recipe.Delete(RecipeToDelete); //will remove recipe from database
            repository.Save();
            return RedirectToAction("Index");
        }
    }
}
