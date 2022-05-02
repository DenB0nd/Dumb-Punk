namespace TextGeneration;

public class TextGeneratorBuilder
{
    private readonly TextGenerator generator;

    public TextGeneratorBuilder()
    {
        generator = new ();
    }

    public TextGeneratorBuilder UsingLibrary(ILibrary library)
    {
        generator.Library = library;
        return this;
    }

    public TextGeneratorBuilder UsingAlgorithm(IGenerator algorithm)
    {
        generator.GenerationAlgorithm = algorithm;
        return this;
    }

    public TextGenerator Build() => generator;
}