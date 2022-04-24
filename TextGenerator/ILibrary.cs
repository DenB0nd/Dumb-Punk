namespace TextGeneration;

public interface ILibrary
{
    public HashSet<string> Dictionary { get; }
    public string RandomStart
    {
        get
        {
            return Dictionary.ElementAt(Random.Shared.Next(Dictionary.Count()));
        }
    }
}
