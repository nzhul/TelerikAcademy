using System;

namespace GenericList
{
    public class GenericList<T> where T : IComparable
    {
        private const int DefaultCapacity = 10;
        private T[] list;
        private int position;

        public GenericList()
            : this(DefaultCapacity)
        { }

        public GenericList(int capacity)
        { 
            this.list = new T[capacity];
        }

        public T this[int index]
        {
            get { return this.list[index]; }
            set { this.list[index] = value; }
        }

        // methods
        public void AddElement(T element)
        { 
            
        }
    }
}
