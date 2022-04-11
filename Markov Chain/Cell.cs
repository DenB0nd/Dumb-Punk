namespace MarkovChain
{
    public class Cell<T> where T : notnull
    {
        public T BaseElement { get; private set; }
        public T LinkedElement { get; private set; }

        public int Number { get; private set; }

        public Cell(T baseElement, T linkedElement)
        {
            BaseElement = baseElement;
            LinkedElement = linkedElement;
            Number = 1;
        }

        public void IncreaseNumber(int quantity = 1) => Number += quantity;

        public bool ConsistOf(T baseElement, T linkedElement)
        {
            return baseElement.Equals(BaseElement) && linkedElement.Equals(LinkedElement);
        }

    }
}