using ProjectCRUDApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCRUDApp.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        IFoodRepository _foods;

        IRecipeRepository _recipes;

        IRestaurantRepository _restaurants;

        public IFoodRepository Food //if foods is null, then create a new food repository and return the foods back
        { get
            { if (_foods==null)
                {
                    _foods = new FoodRepository(_repoContext);
                }
                return _foods;
            }
        }

        public IRecipeRepository Recipe
        {
            get
            { 
                if (_recipes == null)
                {
                    _recipes = new RecipeRepository(_repoContext);
                }
                return _recipes;
            }
        }

        public IRestaurantRepository Restaurant
        {
            get
            {
                if (_restaurants == null)
                {
                    _restaurants = new RestaurantRepository(_repoContext);
                }
                return _restaurants;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
