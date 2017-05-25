using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class Knot : Descendente
    {
        public Knot Parent { get; set; }


        public SortedSet<Key> Keys = new SortedSet<Key>();

        public void AddKey(Key key)
        {
            Keys.Add(key);
        }


    }

}
