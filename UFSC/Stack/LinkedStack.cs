using Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack {
    public class LinkedStack<T> {

        public static void Test() {
            LinkedStack<int> stack = new LinkedStack<int>();


            stack.Push(1);

            stack.Push(2);

            stack.Push(3);

            stack.Push(4);

            stack.Push(5);

        }
        private LinkedElement<T> top;

        public void Push(T valor) {
            if (valor == null) throw new Exception("Invalid value: null");
            LinkedElement<T> element = new LinkedElement<T>(valor);
            element.setParent(top);
            top = element;
        }

        public T Pop() {
            if (Empty) throw new Exception("Stack empty.");
            LinkedElement<T> temp = top;
            top = top.getParent();
            return temp.valor;
        }

        public bool Empty {
            get { return top == null; }
        }

    }
}
