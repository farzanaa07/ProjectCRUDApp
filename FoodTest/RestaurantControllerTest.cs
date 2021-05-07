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

namespace RestaurantTest
{
    public class RestaurantControllerTest
    {

        private Mock<IRepositoryWrapper> mockRepo;
        private RestaurantController restaurantController;
        private UpdateRestaurant updateRestaurant;
        private Restaurant Restaurant;
        private List<Restaurant> Restaurants;
        private Mock<IRestaurant> RestaurantMock;
        private List<IRestaurant> RestaurantsMock;
        private Mock<IAddRestaurant> addRestaurantMock;
        private Mock<IUpdateRestaurant> updateRestaurantMock;
        public RestaurantControllerTest()
        {
            //mock setup
            RestaurantMock = new Mock<IRestaurant>();
            RestaurantsMock = new List<IRestaurant> { RestaurantMock.Object };
            addRestaurantMock = new Mock<IAddRestaurant>();
            updateRestaurantMock = new Mock<IUpdateRestaurant>();
            Restaurant = new Restaurant();
            Restaurants = new List<Restaurant>();
            //viewmodels mock setup


            //sample models
          
            updateRestaurant = new UpdateRestaurant { };

            //controller setup
            var RestaurantResultsMock = new Mock<IActionResult>();

            mockRepo = new Mock<IRepositoryWrapper>();
            var allRestaurants = GetRestaurants();
            restaurantController = new RestaurantController(mockRepo.Object);
        }
        [Fact]
        public void GetAllRestaurants_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Restaurant.FindAll()).Returns(GetRestaurants());
            //Act
            var controllerActionResult = restaurantController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void DetailRestaurant_Test()
        {
            mockRepo.Setup(repo => repo.Restaurant.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetRestaurants());
            var controllerActionResult = restaurantController.Details(It.IsAny<int>());
            Assert.NotNull(controllerActionResult);
        }


        [Fact]
        public void DeleteRestaurant_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Restaurant.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetRestaurants());
            mockRepo.Setup(repo => repo.Restaurant.Delete(GetRestaurant()));
            //Act
            var controllerActionResult = restaurantController.Delete(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        private void UpdateRestaurant_Test()
        {
            mockRepo.Setup(repo => repo.Restaurant.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetRestaurants());
            mockRepo.Setup(repo => repo.Restaurant.Update(GetRestaurant()));
        //Act
        var controllerActionResult = restaurantController.Update(It.IsAny<int>());
        //Assert
        Assert.NotNull(controllerActionResult);
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>
                {
                    new Restaurant() { ID = 1, Name = "Nandos", Location = "London", NameofDish = "Peri Chicken", Delivery = true, ratings = "4" },
                    new Restaurant() { ID = 1, Name = "Nandos", Location = "London", NameofDish = "Peri Chicken", Delivery = true, ratings = "4" }
                };
        return restaurants;
        }
        private Restaurant GetRestaurant()
        {
            return GetRestaurants().ToList()[0];
        }
    }

}