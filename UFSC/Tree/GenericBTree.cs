using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class GenericBTree<K> where K:IComparable
    {
        public GenericKnot<K> Root { get; set; }

        public int Degree { get; set; }

        public GenericBTree(int Degree, IEqualityComparer<K> comparer)
        {
            this.Degree = Degree;
        }

        public void Add(K value)
        {
            new GenericKey<k>
        }
    }
}
