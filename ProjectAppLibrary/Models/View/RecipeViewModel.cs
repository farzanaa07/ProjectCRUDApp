using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAppLibrary.Models.View
{
  public class RecipeViewModel
    {
        public int ID { get; set; }
        public string RecipeName { get; set; }
        public string PictureURL { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public LevelofDifficulty LevelofDifficulty { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
