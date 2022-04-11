namespace TextGeneration
{
    public class TextGenerator
    {
        public IGenerationAlgorithm? GenerationAlgorithm { get; set; }
        public ILibrary? Library { get; set; }

        public static TextGeneratorBuilder CreateBuilder()
        {
            return new TextGeneratorBuilder();
        }

        public string? Generate(string start = "", int count = 1)
        {
            if(GenerationAlgorithm is null || Library is null)
                return null;

            return GenerationAlgorithm.Generate(Library, start, count);
        }
    }
}