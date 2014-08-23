namespace Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MyQueue<T> : IEnumerable<T>
    {
        public QElement<T> firstEement { get; set; }
        public QElement<T> lastElement { get; set; }
        public int Count { get; private set; }

        public MyQueue()
        {
            this.Count = 0;
        }

        public void Enqueue(T element)
        {
            QElement<T> newNode = new QElement<T>(element);
            if (this.Count == 0)
            {
                this.firstEement = newNode;
            }
            else
            {
                this.lastElement = newNode;
            }
            this.lastElement = newNode;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            this.firstEement = this.firstEement.NextElement;
            if (this.Count == 1)
            {
                this.lastElement = null;
            }
            this.Count--;
            return this.firstEement.Value;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            return this.firstEement.Value;
        }

        public void Clear()
        {
            this.firstEement = null;
            this.lastElement = null;
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException("The Queque should not be enumerable by design!");

            //Still there is the code for the enumerator
            // 
            //QElement<T> currentNode = this.firstEement;
            //while (currentNode != null)
            //{
            //    yield return currentNode.Value;
            //    currentNode = currentNode.NextElement;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
