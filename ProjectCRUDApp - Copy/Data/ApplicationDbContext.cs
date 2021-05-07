using Microsoft.EntityFrameworkCore;
using ProjectAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAppLibrary.Models;

namespace ProjectCRUDApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } //constructor chaining where creating a constructor into the DbContext class to pass the DnContext options (child) enttity into base class (parent)
        public DbSet<Recipe> Recipes { get; set; } //will create a table in database called Recipes
        public DbSet<Restaurant> Restaurants { get; set; }
    }
    }

