namespace Tools
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            ArgumentNullException.ThrowIfNull(enumerable, nameof(enumerable));

            var buffer = enumerable.ToArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                int j = Random.Shared.Next(i, buffer.Length);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}