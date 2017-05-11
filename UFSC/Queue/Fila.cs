using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue {

    public class Fila<T> {

        public static void Test() {
            Fila<int> fila = new Fila<int>(5);
            fila.enter(5);
            fila.enter(6);
            fila.enter(7);
            fila.enter(8);
            fila.enter(9);
            Console.WriteLine(fila.leave());
            Console.WriteLine(fila.leave());
            Console.WriteLine(fila.leave());
            Console.WriteLine(fila.leave());
            Console.WriteLine(fila.leave());
            fila.enter(1);
            fila.enter(2);
            Console.WriteLine(fila.leave());
            Console.WriteLine(fila.leave());
            fila.enter(3);
            fila.enter(4);
            fila.enter(5);

            Console.WriteLine(fila.leave());
            Console.WriteLine(fila.leave());
            fila.enter(6);
            Console.WriteLine(fila.leave());
            Console.WriteLine(fila.leave());


        }

        private int first = 0, last = -1;
        private T[] array;

        public Fila(int size) {
            if (size < 1) throw new Exception();
            array = new T[size];
        }

        public bool cheio {
            get {
                if (last == -1) return false;
                return (last + 1) % array.Length == first;
            }
        }

        public void enter(T value) {
            if (cheio)
                throw new Exception();
            last++;
            array[last % array.Length] = value;
        }
        public T leave() {
            if (vazio)
                throw new Exception();
            return array[first++ % array.Length];
        }

        public bool vazio {
            get {
                if (last == -1) return true;
                return last == first - 1;
            }
        }
    }
}
