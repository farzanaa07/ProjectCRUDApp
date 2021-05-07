using ProjectCRUDApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAppLibrary.Models;

namespace ProjectCRUDApp.Repositories
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
