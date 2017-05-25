using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class Key : IComparable
    {
        public Key(int value)
        {
            Value = value;
        }

        public IDescendente Left { get; set; }
        public IDescendente Right { get; set; }

        public int Value { get; set; }

        public bool First { get {
                return (Right == null && Left != null);
            } }

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
