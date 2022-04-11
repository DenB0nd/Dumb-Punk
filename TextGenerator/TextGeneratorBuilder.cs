namespace TextGeneration;

public class TextGeneratorBuilder
{
    private TextGenerator generator;

    public TextGeneratorBuilder()
    {
        this.generator = new ();
    }

    public TextGeneratorBuilder SetLibrary(ILibrary library)
    {
        this.generator.Library = library;
        return this;
    }

    public TextGeneratorBuilder UsingAlgorithm(IGenerationAlgorithm algorithm)
    {
        this.generator.GenerationAlgorithm = algorithm;
        return this;
    }

    public TextGenerator Build() => this.generator;
}