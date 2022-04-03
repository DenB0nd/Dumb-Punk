using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Chain
{
    public sealed class Window<T> : IEquatable<Window<T>>
    {
        public T[] Value { get; init; } = new T[0];

        public Window(IEnumerable<T> collection)
        {
            Value = collection.ToArray();
        }

        public override bool Equals(object? obj)
        {
            Window<T>? windowObj = obj as Window<T>;
            if(windowObj == null)
            {
                return false;
            }
            return Enumerable.SequenceEqual<T>(Value, windowObj.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(Window<T>? other)
        {
            if (other == null)
            {
                return false;
            }
            return Enumerable.SequenceEqual<T>(Value, other.Value);
        }
    }
}
