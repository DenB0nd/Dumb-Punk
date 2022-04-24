namespace TextGeneration;

public class TextGenerator
{
    public IGenerationAlgorithm? GenerationAlgorithm { get; set; }
    public ILibrary? Library { get; set; }

    public static TextGeneratorBuilder CreateBuilder()
    {
        return new TextGeneratorBuilder();
    }

    public string? Generate(string? start = null, int count = 1)
    {
        if (GenerationAlgorithm is null || Library is null)
        {
            return null;
        }
        
        if(start is null)
        {
            start = Library.RandomStart;
        }

        return GenerationAlgorithm.Generate(Library, start, count);
    }
}
