using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectAppLibrary.Models;
using ProjectAppLibrary.Models.Binding;
using ProjectCRUDApp.Controllers;
using ProjectCRUDApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingLibrary;
using TestingLibrary.Testing.InterfaceTesting;
using Xunit;

namespace FoodTest
{
    public class FoodControllerTest
    {
        private Mock<IFood> foodMock;
        private Mock<IRepositoryWrapper> mockRepo;
        private FoodController foodController;
        private AddFoodBindingModel addFoods;
        private Food food;
        private List<Food> foods;
        private UpdateFoods updateFood;
        private List<IFood> foodsMock;
        private readonly Mock<IAddFood> addFoodMock;
        private readonly Mock<IUpdateFood> updatefoodMock;
       
        private AddRecipeBindingModel addRecipe;
        private Recipe Recipe;
        private List<Recipe> Recipes;
        private Mock<IRecipe> RecipeMock;
        private List<IRecipe> RecipesMock;
        private Mock<IAddRecipe> addRecipeMock;

        private AddRestaurantBindingModel addRestaurant;
        private Restaurant Restaurant;
        private List<Restaurant> Restaurants;
        private Mock<IRestaurant> RestaurantMock;
        private List<IRestaurant> RestaurantsMock;
        private Mock<IAddRestaurant> addRestaurantMock;
      
        public FoodControllerTest()
        {
            //mock setup
            foodMock = new Mock<IFood>();
            foodsMock = new List<IFood> { foodMock.Object };
            addFoodMock = new Mock<IAddFood>();
            updatefoodMock = new Mock<IUpdateFood>();
            food = new Food();
            foods = new List<Food>();

            //sample models
            addFoods = new AddFoodBindingModel { Name = "Lasagne", Cuisine = "Italian", Description = "layers of meat, cheese and pasta" };
            updateFood = new UpdateFoods { Name = "Lasagne", Cuisine = "English", Description = "layers of meat, cheese and pasta" };
            addRestaurant = new AddRestaurantBindingModel { };
            addRecipe = new AddRecipeBindingModel { };
            
            //controller setup
            var recipeMock = new Mock<IRecipe>();
            var recipesMock = new List<IRecipe>() { recipeMock.Object };
            var foodResultsMock = new Mock<IActionResult>();


            mockRepo = new Mock<IRepositoryWrapper>();
            foodController = new FoodController(mockRepo.Object);
            var allfoods = GetFoods();
            var allrecipes = GetRecipes();
        }

        [Fact]
        public void GetFoods_Test()
        {

            //Arrange set up repository to be used
            mockRepo.Setup(repo => repo.Food.FindAll()).Returns(GetFoods());
            mockRepo.Setup(repo => repo.Restaurant.FindByCondition(r => r.FoodID == It.IsAny<int>())).Returns(GetRestaurants());
            mockRepo.Setup(repo => repo.Recipe.FindByCondition(r => r.FoodID == It.IsAny<int>())).Returns(GetRecipes());
            //Act
            var controllerActionResult = foodController.Index();
            //Asset
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void DetailFoods_Test()
        {
            mockRepo.Setup(repo => repo.Food.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetFoods());
            var controllerActionResult = foodController.Details(It.IsAny<int>());
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void AddFood_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Food.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetFoods());

            //Act
            var controllerActionResult = foodController.Create(addFoods);

            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<RedirectToActionResult>(controllerActionResult);

        }
        [Fact]
        public void UpdateRecipe_Test()
        {
            mockRepo.Setup(repo => repo.Food.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetFoods());
            mockRepo.Setup(repo => repo.Food.Update(GetFood()));
            //Act
            var controllerActionResult = foodController.Update(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void DeleteFood_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Food.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetFoods());
            mockRepo.Setup(repo => repo.Food.Delete(GetFood()));
            mockRepo.Setup(repo => repo.Recipe.FindByCondition(r => r.FoodID == It.IsAny<int>())).Returns(GetRecipes());
            mockRepo.Setup(repo => repo.Restaurant.FindByCondition(r => r.FoodID == It.IsAny<int>())).Returns(GetRestaurants());
            //Act
            var controllerActionResult = foodController.Delete(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<RedirectToActionResult>(controllerActionResult);
        }
       
        [Fact]
        public void AddRecipe_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Recipe.FindByCondition(r => r.FoodID == It.IsAny<int>())).Returns(GetRecipes());
            //Act
            var controllerActionResult = foodController.CreateRecipe(addRecipe,It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<RedirectToActionResult>(controllerActionResult);
        }
        [Fact]
        public void AddRestaurant_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Restaurant.FindByCondition(r => r.FoodID == It.IsAny<int>())).Returns(GetRestaurants());
            //Act
            var controllerActionResult = foodController.CreateRestaurant(addRestaurant,It.IsAny<int>());
            
            Assert.NotNull(controllerActionResult);
            Assert.IsType<RedirectToActionResult>(controllerActionResult);
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            return new List<Restaurant>()
            {
                new Restaurant { ID = 1, Name = "Nandos", Location = "London", NameofDish = "Peri Chicken", Delivery = true, ratings = "4" }
            };
        }
        private Restaurant GetRestaurant()
        {
            return GetRestaurants().ToList()[0];
        }
        private IEnumerable<ProjectAppLibrary.Models.Recipe> GetRecipes()
        {
            return new List<Recipe>()
            {
                new Recipe { ID = 1, RecipeName = "Chocolate cake", Ingredients = "chocolate, flour, eggs, cocoa powder, sugar", Method = "mix all ingredients and place in oven", Servings = 8}
            };
        }

        private Recipe GetRecipe()
        {
            return GetRecipes().ToList()[0];
        }

        private IEnumerable<Food> GetFoods()
        {
            var foods = new List<Food>
                {
                    new Food() { ID = 1, Name = "Chicken fajitas", Cuisine = "Mexican", Description = "seasoned chicken in wraps",PictureURL="https://storcpdkenticomedia.blob.core.windows.net/media/recipemanagementsystem/media/recipe-media-files/recipes/retail/x17/18745-italian-chicken-wraps-600x600.jpg?ext=.jpg" },
                    new Food() { ID = 2, Name = "Cookies", Cuisine = "Baking", Description = "chocolate chip soft cookies", PictureURL="https://storcpdkenticomedia.blob.core.windows.net/media/recipemanagementsystem/media/recipe-media-files/recipes/retail/x17/18745-italian-chicken-wraps-600x600.jpg?ext=.jpg" }
                };
            return foods;
        }
        private Food GetFood()
        {
            return GetFoods().ToList()[0];
        }
    }
}













