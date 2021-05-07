using ProjectAppLibrary;
using ProjectAppLibrary.Models.Utility;
using ProjectAppLibrary.Models.View;
using System;
using System.Collections.Generic;
using Xunit;


namespace ProjectXUnit.Utiliity
{
    public class RecipeUtilityTest
    {
        [Fact] //annnotated with facts block which represents test case
        public void GetViewModel()
        {
            //Arrange - set object
            Recipe testRecipe = new Recipe()
            {
                ID = 1,
                RecipeName = "Lasagne",
                Ingredients = "lasagne sheets, minced meat, white sauce, cheese",
                Method = "layer all ingredients",
                PictureURL= "https://static01.nyt.com/images/2021/01/26/well/well-foods-microbiome/well-foods-microbiome-mobileMasterAt3x.jpg",
                LevelofDifficulty = ProjectAppLibrary.Models.LevelofDifficulty.Intermediate,
                CreatedAt=DateTime.Now
            };
            //Act
            var testRecipeVM = testRecipe.GetViewModel();
            //Assert
            Assert.IsType<RecipeViewModel>(testRecipeVM);
            Assert.NotNull(testRecipeVM);
            Assert.NotEmpty(testRecipeVM.PictureURL);
        }
        
    }
}
