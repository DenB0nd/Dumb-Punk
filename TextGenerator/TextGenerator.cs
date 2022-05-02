namespace TextGeneration;

public class TextGenerator
{
    public IGenerator? GenerationAlgorithm { get; set; }
    public ILibrary? Library { get; set; }

    public static TextGeneratorBuilder CreateBuilder()
    {
        return new TextGeneratorBuilder();
    }

    public string Generate(string? start = null, int count = 1)
    {
        if (GenerationAlgorithm is null || Library is null)
        {
            return string.Empty;
        }

        if (start is null)
        {
            start = Library.Dictionary.ElementAt(Random.Shared.Next(Library.Dictionary.Count()));
        }

        return GenerationAlgorithm.Generate(Library, start, count);
    }
}

  
