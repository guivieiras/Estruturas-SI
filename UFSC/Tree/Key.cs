using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class Key : IComparable
    {
        public Descendente Left { get; set; }
        public Descendente Right { get; set; }

        public int Value { get; set; }

        public int CompareTo(object obj)
        {
            if (obj.GetType() != this.GetType()) return 0;
            else
            {
                Key o = obj as Key;

                if (o.Value > Value) return -1;
                if (o.Value == Value) return 0;
                else return 1;
            }
        }
    }
}
