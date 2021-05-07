using ProjectAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAppLibrary.Models.Binding
{
    public class AddRecipeBindingModel
    {

        public string RecipeName { get; set; }
       
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public int Servings { get; set; }
        public LevelofDifficulty LevelofDifficulty { get; set; }
        public int FoodID { get; set; }
    }
}
