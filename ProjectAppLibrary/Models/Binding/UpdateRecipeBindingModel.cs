using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAppLibrary.Models.Binding
{
    class UpdateRecipeBindingModel
    {
        public string RecipeName { get; set; }
        public string PictureURL { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public LevelofDifficulty LevelofDifficulty { get; set; }
    }
}
