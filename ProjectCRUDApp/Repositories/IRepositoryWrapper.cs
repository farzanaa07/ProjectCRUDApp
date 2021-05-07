using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCRUDApp.Repositories
{
    public interface IRepositoryWrapper
    {
        IFoodRepository Food { get; }
        IRecipeRepository Recipe { get; }
        IRestaurantRepository Restaurant { get; }
        void Save();
    } 
}
