namespace TextGeneration;

public interface IGenerator
{
    public string Generate(ILibrary library, string start = "", int count = 1);
}
