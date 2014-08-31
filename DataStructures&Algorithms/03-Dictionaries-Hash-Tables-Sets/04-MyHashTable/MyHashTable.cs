using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashTable
{
    public class MyHashTable<K, T> : IEnumerable<KeyValuePair<K, T>> 
    {
  private const int InitialCapacity = 16;
        private LinkedList<KeyValuePair<K, T>>[] hashHolder;
        private int capacity = InitialCapacity;

        public MyHashTable()
        {
            this.hashHolder = new LinkedList<KeyValuePair<K, T>>[this.capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public List<K> Keys
        {
            get
            {
                List<K> currKeys = new List<K>();

                foreach (var item in this.hashHolder)
                {
                    if (item != null)
                    {
                        var currItem = item.First;
                        while (currItem != null)
                        {
                            currKeys.Add(currItem.Value.Key);
                            currItem = currItem.Next;
                        }
                    }
                }

                return currKeys;
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                if (!this.Update(key, value))
                {
                    this.Add(key, value);    
                }
            }
        }

        private bool Update(K key, T value)
        {
            var index = GetIndex(key);
            if (this.hashHolder[index] != null)
            {
                foreach (var item in this.hashHolder[index])
                {
                    if (item.Key.Equals(key))
                    {
                        this.hashHolder[index].Remove(item);
                        var pair = new KeyValuePair<K, T>(key, value);
                        this.hashHolder[index].AddLast(pair);
                        return true;
                    }
                }
            }
            return false;
        }

        public void Add(K key, T value)
        {
            DoubleCapacityIfNeeded();

            this.Count++;
            var index = GetIndex(key);
            if (this.hashHolder[index] == null)
            {
                this.hashHolder[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            var pair = new KeyValuePair<K, T>(key, value);
            this.hashHolder[index].AddLast(pair);
        }

        public T Find(K key)
        {
            var index = GetIndex(key);

            if (this.hashHolder[index] != null)
            {
                var currItem = this.hashHolder[index].First;
                while (currItem != null)
                {
                    if (currItem.Value.Key.Equals(key))
                    {
                        return currItem.Value.Value;
                    }

                    currItem = currItem.Next;
                }
            }

            throw new ArgumentException("No element with this key!");
        }

        public void Remove(K key)
        {
            var index = GetIndex(key);

            if (this.hashHolder[index] != null)
            {
                var currItem = this.hashHolder[index].First;
                while (currItem != null)
                {
                    if (currItem.Value.Key.Equals(key))
                    {
                        this.hashHolder[index].Remove(currItem);
                    }

                    currItem = currItem.Next;
                }
            }
        }

        public void Clear()
        {
            this.capacity = InitialCapacity;
            this.Count = 0;
            this.hashHolder = new LinkedList<KeyValuePair<K, T>>[this.capacity];
        }

        private void DoubleCapacityIfNeeded()
        {
            if (this.Count >= this.capacity * 0.75)
            {
                this.capacity *= 2;
                var currHashHolder = this.hashHolder;
                hashHolder = new LinkedList<KeyValuePair<K, T>>[this.capacity];

                for (int i = 0; i < this.Count; i++)
                {
                    hashHolder[i] = currHashHolder[i];
                }
            }
        }

        private int GetIndex(K key)
        {
            var index = Math.Abs(key.GetHashCode() % this.capacity);
            return index;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.hashHolder)
            {
                if (list != null)
                {
                    foreach (var listItem in list)
                    {
                        yield return listItem;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
