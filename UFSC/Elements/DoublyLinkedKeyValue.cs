using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements {
    public class DoublyLinkedKeyValue<K, V>  {
        public K ID;
        public V Value;

        public DoublyLinkedKeyValue(K ID, V Value){
            this.Value = Value;
            this.ID = ID;
        }

        public DoublyLinkedKeyValue<K, V> Next;
        public DoublyLinkedKeyValue<K, V> Previous;
    }
}
