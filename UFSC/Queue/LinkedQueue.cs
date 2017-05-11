using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue {
    using Elements;
    using System;

    public class LinkedQueue<T> {
        public static void Test() {

            LinkedQueue<int> q = new LinkedQueue<int>();

            q.Enter(1);
            q.Enter(2);
            q.Enter(3);
            q.Enter(4);
            q.Enter(5);
            Console.WriteLine(q.leave());
            Console.WriteLine(q.leave());
            q.Enter(6);
            q.Enter(7);
            Console.WriteLine(q.leave());
            Console.WriteLine(q.leave());
            Console.WriteLine(q.leave());
            Console.WriteLine(q.leave());
            Console.WriteLine(q.leave());
            q.Enter(31231);
            Console.WriteLine(q.leave());
            Console.WriteLine(q.leave());
        }

        private LinkedElement<T> first;
        private LinkedElement<T> last;

        public void Enter(T valor) {
            if (valor == null) throw new Exception("Invalid value: null");
            LinkedElement<T> element = new LinkedElement<T>(valor);
            if (first == null) first = element;
            if (last != null) last.setParent(element);
            last = element;
        }
        public T leave() {
            if (Empty) throw new Exception("Queue empty.");
            LinkedElement<T> temp = first;
            first = first.getParent();
            return temp.valor;
        }
        public bool Empty {
            get { return first == null; }
        }

    }





}
