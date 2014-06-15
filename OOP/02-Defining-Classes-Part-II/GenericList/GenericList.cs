using System;
using System.Text;

namespace GenericList
{
    public class GenericList<T>
    {
        private const int DefaultCapacity = 16;
        private T[] elements;
        private int nextElement;
        private int capacity;

        // Return the count of the elements in the list
        public int Count
        {
            get { return this.nextElement; }
        }

        // Constructors
        public GenericList()
            : this(DefaultCapacity)
        { }

        public GenericList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("The Value must be positive.");
            }
            else
            {
                this.elements = new T[capacity];
                this.nextElement = 0;
                this.capacity = capacity;
            }
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                if (isInRange(index))
                {
                    return this.elements[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
            }
            set
            {
                if (isInRange(index))
                {
                    this.elements[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
            }
        }

        // Add element to the list
        public void AddElement(T element)
        {
            if (this.nextElement >= this.capacity)
            {
                Grow();
            }
            this.elements[this.nextElement] = element;
            this.nextElement++;
        }

        // Remove element at given position
        public void RemoveElementAtIndex(int index)
        {
            if (isInRange(index))
            {
                T nextElement = default(T);
                for (int i = index; i < this.elements.Length - 1; i++)
                {
                    nextElement = this.elements[i + 1];
                    this.elements[i] = nextElement;
                }
                this.nextElement--;
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
        }

        // Insert element at given position
        public void InsertElementAt(int index, T element)
        {
            if (isInRange(index))
            {
                if (this.nextElement >= this.capacity)
                {
                    Grow();
                }
                for (int i = this.nextElement ; i > index; i--)
                {
                    this.elements[i] = this.elements[i - 1];
                }
                this.elements[index] = element;
                this.nextElement++;
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
        }

        // Clearing the list
        public void ClearList()
        {
            this.elements = new T[this.capacity];
            this.nextElement = 0;
        }

        // Find Element by it's value
        public int FindElementIndex(T searchedValue)
        {
            return Array.IndexOf(this.elements, searchedValue);
        }

        private void Grow()
        {
            T[] tempList = new T[this.capacity];
            this.elements.CopyTo(tempList, 0);
            this.capacity *= 2;
            this.elements = new T[this.capacity];
            tempList.CopyTo(this.elements, 0);
        }

        private bool isInRange(int index)
        {
            if (index < 0 || index >= this.nextElement)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.nextElement; i++)
            {
                builder.Append(String.Format("{0}, ", this.elements[i]));
            }
            return builder.ToString();
        }
    }
}
