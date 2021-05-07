using ProjectAppLibrary.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAppLibrary.Models.Utility
{
    public static class RecipeUtility
    {
        public static RecipeViewModel GetViewModel(this Recipe recipe) //an extension method
        {
            var recipeVM = new RecipeViewModel()
            {
                RecipeName = recipe.RecipeName,
                Ingredients = recipe.Ingredients,
                Method = recipe.Method,
                LevelofDifficulty = recipe.LevelofDifficulty,
                CreatedAt = recipe.CreatedAt,
                ID = recipe.ID,
                PictureURL = recipe.PictureURL
            };
            return recipeVM;
        }

        public static List<RecipeViewModel> GetViewModels(this List<Recipe> recipes)
         {
            var allRecipeVM = new List<RecipeViewModel>();
            foreach(var recipe in recipes)
            {
                allRecipeVM.Add(new RecipeViewModel()
                { 
                RecipeName=recipe.RecipeName,
                Ingredients=recipe.Ingredients,
                Method=recipe.Method,
                PictureURL=recipe.PictureURL,
                LevelofDifficulty=recipe.LevelofDifficulty
            });
        }
            return allRecipeVM;
            {

        }

        }

    }
  
    }

