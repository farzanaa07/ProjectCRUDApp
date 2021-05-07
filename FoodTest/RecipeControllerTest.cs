using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using ProjectCRUDApp.Controllers;
using TestingLibrary.Testing.InterfaceTesting;
using ProjectCRUDApp.Repositories;
using ProjectAppLibrary.Models;

namespace RecipesTest
{
    public class RecipeControllerTest
    {

        private Mock<IRepositoryWrapper> mockRepo;
        private RecipeController recipeController;

        private UpdateRecipe updateRecipe;
        private Recipe Recipe;
        private List<Recipe> Recipes;
        private Mock<IRecipe> RecipeMock;
        private List<IRecipe> RecipesMock;
        private Mock<IUpdateRecipe> updateRecipeMock;
        public RecipeControllerTest()
        {
            //mock setup
            RecipeMock = new Mock<IRecipe>();
            RecipesMock = new List<IRecipe> { RecipeMock.Object };
            updateRecipeMock = new Mock<IUpdateRecipe>();
            Recipe = new Recipe();
            Recipes = new List<Recipe>();
            //viewmodels mock setup


            //sample models
            updateRecipe = new UpdateRecipe { };

            //controller setup
            var RecipeResultsMock = new Mock<IActionResult>();

            mockRepo = new Mock<IRepositoryWrapper>();
            var allRecipes = AllRecipes();
            recipeController = new RecipeController(mockRepo.Object);
        }
        [Fact]
        public void GetAllRecipes_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Recipe.FindAll()).Returns(AllRecipes());
            //Act
            var controllerActionResult = recipeController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void DetailRecipe_Test()
        {
            mockRepo.Setup(repo => repo.Recipe.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(AllRecipes());
            var controllerActionResult = recipeController.Details(It.IsAny<int>());
            Assert.NotNull(controllerActionResult);
        }
        [Fact]

        public void UpdateRecipe_Test()
        {
            mockRepo.Setup(repo => repo.Recipe.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(AllRecipes());
            mockRepo.Setup(repo => repo.Recipe.Update(GetRecipe()));
            //Act
            var controllerActionResult = recipeController.Update(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }


        [Fact]
        public void DeleteRecipe_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Recipe.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(AllRecipes());
            mockRepo.Setup(repo => repo.Recipe.Delete(GetRecipe()));
            //Act
            var controllerActionResult = recipeController.Delete(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        private IEnumerable<Recipe>AllRecipes()
        {
            var recipes = new List<Recipe>
                {
                    new Recipe() { ID = 1, RecipeName = "Chocolate cake", Ingredients = "chocolate, flour, eggs, cocoa powder, sugar", Method = "mix all ingredients and place in oven", Servings = 8 },
                    new Recipe() { ID = 1, RecipeName = "Chocolate cake", Ingredients = "chocolate, flour, eggs, cocoa powder, sugar", Method = "mix all ingredients and place in oven", Servings = 8 }
               };
        return recipes;
            }
            private Recipe GetRecipe()
        {
            return AllRecipes().ToList()[0];
        }

    }

}