using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace BiDictionary
{
    public class BiDictionary<TKey1, Tkey2, TValue>
    {
        private class Entry : IEquatable<Entry>
        {

            public TKey1 Key1 { get; set; }
            public Tkey2 Key2 { get; set; }
            public TValue Value { get; set; }

            public Entry(TKey1 key1, Tkey2 key2, TValue value)
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


    }
}
