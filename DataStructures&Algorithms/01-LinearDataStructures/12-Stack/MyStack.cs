namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class MyStack<T> : IEnumerable<T>
    {
        private const int BaseCapacity = 4;
        private T[] stack;
        public int Count { get; private set; }

        public MyStack()
            :this(BaseCapacity)
        {
        }

        public MyStack(int capacity)
        {
            this.stack = new T[capacity];
            this.Count = 0;
        }

        public void Push(T item)
        {
            if (this.Count == this.stack.Length - 1)
            {
                T[] temp = new T[this.stack.Length * 2];
                Array.Copy(this.stack, temp, this.Count);
                this.stack = temp;
            }
            this.stack[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            this.Count--;
            return this.stack[this.Count + 1];
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return this.stack[this.Count - 1];
        }

        public bool Contains(T item)
        {
            foreach (var element in this.stack)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            this.Count = 0;
        }



        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
