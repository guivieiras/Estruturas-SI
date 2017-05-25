using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class GenericElement<V>
    {
        public V Value { get; set; }

        public GenericElement(V value)
        {
            Value = value;
            System.Collections.Hashtable a = new System.Collections.Hashtable()
        }
    }
}
