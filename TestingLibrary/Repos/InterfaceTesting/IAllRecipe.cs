using ProjectAppLibrary.Models;

namespace TestingLibrary.Testing.InterfaceTesting
{
    public interface IAllRecipe
    {
        public int ID { get; set; }
        public string RecipeName { get; set; }
        public string PictureURL { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public int Servings { get; set; }
        public LevelofDifficulty LevelofDifficulty { get; set; }
    }


}
