namespace _03.GenericSwapMethodStrings
{
    public class Box<T>
    {
        private T element;

        public T Element
        {
            get { return element; }
            set { element = value; }
        }

        public Box(T element)
        {
            Element = element;
        }

        public override string ToString()
        {
            return $"{Element.GetType()}: {Element}";
        }
    }
}
