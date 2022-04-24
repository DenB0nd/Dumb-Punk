namespace TextGeneration;

public interface ILibrary
{
    public HashSet<string> Dictionary { get; init; }
    public string RandomStart
    {
        get
        {
            return Dictionary.ElementAt(Random.Shared.Next(Dictionary.Count()));
        }
    }
}
