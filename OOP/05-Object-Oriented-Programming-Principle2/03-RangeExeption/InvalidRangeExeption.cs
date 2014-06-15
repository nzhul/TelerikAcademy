using System;

namespace RangeExeption
{
    public class InvalidRangeException<T> : Exception
    {
        // Properties
        private T start;
        private T end;
        private const string Message = "Out of range!";

        public T Start
        {
            get { return this.start; }
            set { this.start = value; }
        }

        public T End
        {
            get { return this.end; }
            set { this.end = value; }
        }

        
        // Fields


        // Constructor
        public InvalidRangeException(T start, T end, Exception innerException = null)
            : base(Message, innerException)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
