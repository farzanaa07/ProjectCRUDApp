using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCRUDApp.Data;
using ProjectAppLibrary.Models;

namespace ProjectCRUDApp.Repositories
{
   public class FoodRepository:Repository<Food>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
