using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class Element : IDescendente
    {
        public Element(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}
