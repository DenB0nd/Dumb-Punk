namespace TextGeneration
{
    public class TextGeneratorBuilder
    {
        private TextGenerator generator;

        public TextGeneratorBuilder()
        {
            generator = new();
        }

        public TextGeneratorBuilder SetLibrary(ILibrary library)
        {
            generator.Library = library;
            return this;
        }

        public TextGeneratorBuilder UsingAlgorithm(IGenerationAlgorithm algorithm)
        {
            generator.GenerationAlgorithm = algorithm;
            return this;
        }

        public TextGenerator Build() => generator;
    }
}
