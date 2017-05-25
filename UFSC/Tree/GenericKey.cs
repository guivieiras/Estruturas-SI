using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class GenericKey<K> where K : IComparable
    {
        public GenericKey<K> Parent { get; set; }
        public GenericKnot<K> Left { get; set; }
        public GenericKnot<K> Right { get; set; }



        public K Value { get; set; }
    }
}
