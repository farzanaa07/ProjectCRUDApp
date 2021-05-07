namespace TestingLibrary.Testing.InterfaceTesting
{
    public interface IAddRecipe
    {
        public string RecipeName { get; set; }
        public string PictureURL { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public int Servings { get; set; }
    }


}
