using ProjectAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCRUDApp.Data;

namespace ProjectCRUDApp.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}