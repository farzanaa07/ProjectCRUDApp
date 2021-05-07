using ProjectAppLibrary.Models;
using ProjectCRUDApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectXUnit.Class
{
    public class FoodTest
    {
        [Fact]
        public void FoodTests()
        //Assert
        {
            Food testFood = new Food()
            {
                ID = 1,
                Name = "Lasagne",
                PictureURL = "",
                Cuisine = "Italian",
                Description = "a dish with layers of lasagne sheets, minced meat and white sauce.",
                CreatedAt = DateTime.Now

            };
            //Act
            var testFoods = testFood.Cuisine;


            //Assert
            Assert.IsType<System.String>(testFoods);
            Assert.NotNull(testFoods);
           
        }
    }
}
