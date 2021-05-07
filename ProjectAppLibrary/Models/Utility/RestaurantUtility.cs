using ProjectAppLibrary.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAppLibrary.Models.Utility
{
    public static class RestaurantUtility
    {
        public static RestaurantViewModel GetViewModel(this Restaurant restaurant) //an extension method
        {
            var restaurantVM = new RestaurantViewModel()
            {
                Name = restaurant.Name,
                Location = restaurant.Location,
                Delivery = restaurant.Delivery,
                PictureURL = restaurant.PictureURL,
                NameofDish = restaurant.NameofDish,
                ID = restaurant.ID,
                ratings = restaurant.ratings
            };
            return restaurantVM;
        }

        public static List<RestaurantViewModel> GetViewModels(this List<Restaurant> restaurants)
        {
            var allrestaurantVM = new List<RestaurantViewModel>();
            foreach (var restaurant in restaurants)
            {
                allrestaurantVM.Add(new RestaurantViewModel()
                {
                    Name = restaurant.Name,
                    Location = restaurant.Location,
                    Delivery = restaurant.Delivery,
                    PictureURL = restaurant.PictureURL,
                    NameofDish = restaurant.NameofDish,
                    ID = restaurant.ID,
                    ratings = restaurant.ratings
                });
            }
            return allrestaurantVM;


        }
    }
}
