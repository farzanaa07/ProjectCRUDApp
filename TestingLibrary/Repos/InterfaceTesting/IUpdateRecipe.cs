namespace TestingLibrary.Testing.InterfaceTesting
{
    public interface IUpdateRecipe
    {
        public string RecipeName { get; set; }
        public string PictureURL { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public int Servings { get; set; }
    }


}
