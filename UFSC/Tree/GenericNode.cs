using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class GenericNode<K> where K : IComparable
    {
        public List<GenericKey<K>> Keys = new List<GenericKey<K>>();
    }
}
