namespace Queue
{
    public class QElement<T>
    {
        public T Value { get; set; }
        public QElement<T> NextElement { get; set; }

        public QElement(T value)
        {
            this.Value = value;
        }
    }
}
