using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class BTree
    {
        private Knot Root;
        private int Degree;
        public BTree (int Degree)
        {
            this.Degree = Degree;
        }

        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new Knot();
                
            }
        }
    }
}
