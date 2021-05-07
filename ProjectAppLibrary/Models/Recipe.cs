using System;
using System.Collections.Generic;

namespace ProjectAppLibrary.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public int FoodID { get; set; }
        public string RecipeName { get; set; }
        public string PictureURL { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public int Servings { get; set; }
      public LevelofDifficulty LevelofDifficulty { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Food Food { get; set; }


    }
  
}
