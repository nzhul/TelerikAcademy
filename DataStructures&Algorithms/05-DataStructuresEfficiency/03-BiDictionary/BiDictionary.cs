using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace BiDictionary
{
    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private class Entry : IEquatable<Entry>
        {
            public TKey1 Key1 { get; private set; }
            public TKey2 Key2 { get; private set; }
            public TValue Value { get; private set; }

            public Entry(TKey1 key1, TKey2 key2, TValue value)
            {
                this.Key1 = key1;
                this.Key2 = key2;
                this.Value = value;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Entry);
            }

            public bool Equals(Entry other)
            {
                return other != null &&
                    this.Key1.Equals(other.Key1) &&
                    this.Key2.Equals(other.Key2) &&
                    this.Value.Equals(other.Value);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 0;

                    hashCode = (hashCode * 397) ^ this.Key1.GetHashCode();
                    hashCode = (hashCode * 397) ^ this.Key2.GetHashCode();
                    hashCode = (hashCode * 397) ^ this.Value.GetHashCode();

                    return hashCode;
                }
            }
        }

        private readonly MultiDictionary<TKey1, Entry> byKey1 = null;
        private readonly MultiDictionary<TKey2, Entry> byKey2 = null;
        private readonly MultiDictionary<Tuple<TKey1, TKey2>, Entry> byKey1Key2 = null;

        public BiDictionary(bool allowDuplicateValues)
        {
            this.byKey1 = new MultiDictionary<TKey1, Entry>(allowDuplicateValues);
            this.byKey2 = new MultiDictionary<TKey2, Entry>(allowDuplicateValues);
            this.byKey1Key2 = new MultiDictionary<Tuple<TKey1, TKey2>, Entry>(allowDuplicateValues);
        }

        public int Count
        {
            get
            {
                Debug.Assert(
                    byKey1.KeyValuePairs.Count == byKey1Key2.KeyValuePairs.Count &&
                    byKey2.KeyValuePairs.Count == byKey1Key2.KeyValuePairs.Count
                );

                return this.byKey1Key2.KeyValuePairs.Count;
            }
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            var entry = new Entry(key1, key2, value);

            this.byKey1.Add(key1, entry);
            this.byKey2.Add(key2, entry);

            var key1key2 = new Tuple<TKey1, TKey2>(key1, key2);
            this.byKey1Key2.Add(key1key2, entry);
        }

        public ICollection<TValue> GetByFirstKey(TKey1 key1)
        {
            return this.byKey1[key1].Select(entry => entry.Value).ToArray();
        }

        public void RemoveByFirstKey(TKey1 key1)
        {
            var entries = this.byKey1[key1];

            foreach (var entry in entries)
            {
                this.byKey2.Remove(entry.Key2, entry);

                var key1key2 = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);
                this.byKey1Key2.Remove(key1key2, entry);
            }

            this.byKey1.Remove(key1);
        }

        public ICollection<TValue> GetBySecondKey(TKey2 key2)
        {
            return this.byKey2[key2].Select(entry => entry.Value).ToArray();
        }

        public void RemoveBySecondKey(TKey2 key2)
        {
            var entries = this.byKey2[key2];

            foreach (var entry in entries)
            {
                this.byKey1.Remove(entry.Key1, entry);

                var key1key2 = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);
                this.byKey1Key2.Remove(key1key2, entry);
            }

            this.byKey2.Remove(key2);
        }

        public ICollection<TValue> GetByFirstAndSecondKey(TKey1 key1, TKey2 key2)
        {
            var key1key2 = new Tuple<TKey1, TKey2>(key1, key2);

            return this.byKey1Key2[key1key2].Select(entry => entry.Value).ToArray();
        }

        public void RemoveByFirstAndSecondKey(TKey1 key1, TKey2 key2)
        {
            var key1key2 = new Tuple<TKey1, TKey2>(key1, key2);
            var entries = this.byKey1Key2[key1key2];

            foreach (var entry in entries)
            {
                this.byKey1.Remove(entry.Key1, entry);
                this.byKey2.Remove(entry.Key2, entry);
            }

            this.byKey1Key2.Remove(key1key2);
        }
    }
}
