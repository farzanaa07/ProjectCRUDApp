using Microsoft.EntityFrameworkCore;
using ProjectAppLibrary;
using ProjectAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //chaining over constructor
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Restaurant>Restaurants {get; set;}
        public DbSet<Food> Foods { get; set; }
    }
}
