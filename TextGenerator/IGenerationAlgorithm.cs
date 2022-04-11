namespace TextGeneration
{
    public interface IGenerationAlgorithm
    {
        public string? Generate(ILibrary library, string start = "", int count = 1);
    }
}