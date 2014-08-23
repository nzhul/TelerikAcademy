namespace LinkedList
{
    public class ListElement<T>
    {
        public T Value { get; set; }
        public ListElement<T> NextElement { get; set; }

        public ListElement(T value)
        {
            this.Value = value;
        }
    }
}
