namespace TextGeneration;

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
        if (this.GenerationAlgorithm is null || this.Library is null)
        {
            return null;
        }

        return this.GenerationAlgorithm.Generate(this.Library, start, count);
    }
}
