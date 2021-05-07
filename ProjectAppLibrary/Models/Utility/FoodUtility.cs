using ProjectAppLibrary.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAppLibrary.Models.Utility
{
    public static class FoodUtility
    {
        public static FoodViewModel GetViewModel(this Food food)
        {
            var foodVM = new FoodViewModel()
            {
                Name = food.Name,
                PictureURL = food.PictureURL,
                Cuisine = food.Cuisine,
                Description = food.Description,
                ID = food.ID
            };
            return foodVM;
        }
        public static List<FoodViewModel> GetViewModels(this List<Food> foods)
        {
            var allFoodVM = new List<FoodViewModel>();
            foreach (var food in foods)
            {
                allFoodVM.Add(new FoodViewModel()
                {
                    Name = food.Name,
                    PictureURL = food.PictureURL,
                    Cuisine = food.Cuisine,
                    Description = food.Description,
                    ID = food.ID
                });
            }
            return allFoodVM;
            {

            }

        }
    }
}
    