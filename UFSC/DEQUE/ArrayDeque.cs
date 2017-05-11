using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEQUE {
    public class ArrayDeque<T> {

        public static void Test() {
            ArrayDeque<int> ad = new ArrayDeque<int>(4);

            ad.PushBack(1);
            ad.PushFront(90);
            ad.PushFront(20);
            Console.WriteLine(ad.PopBack());
            Console.WriteLine(ad.PopBack());
            Console.WriteLine(ad.PopBack());
            ad.PushFront(3131);
            ad.PushFront(5235);
            ad.PushBack(75675);
            ad.PushFront(34534);
            Console.WriteLine(ad.PopFront());
            Console.WriteLine(ad.PopFront());
            Console.WriteLine(ad.PopBack());
            Console.WriteLine(ad.PopBack());

        }


        private T[] array;

        private int ElementCount = 0;
        private int First = 0;
        private int Last = -1;

        public ArrayDeque(int size) {
            if (size < 1) throw new Exception();
            array = new T[size];
        }

        public void PushBack(T valor) {
            if (Full) throw new Exception("DEQUE is full.");
            if (valor == null) throw new Exception("Invalid value: null");

            ElementCount++;

            array[FixIndex(++Last)] = valor;
        }
        public T PopBack() {
            if (Empty) throw new Exception("DEQUE empty.");

            ElementCount--;

            return array[FixIndex(Last--)];
        }

        public void PushFront(T valor) {
            if (Full) throw new Exception("DEQUE is full.");
            if (valor == null) throw new Exception("Invalid value: null");

            ElementCount++;

            array[FixIndex(--First)] = valor;
        }
        public T PopFront() {
            if (Empty) throw new Exception("DEQUE empty.");

            ElementCount--;

            return array[FixIndex(First++)];
        }


        private int FixIndex(int index) {
            if (index < 0) return (array.Length - Math.Abs(index % array.Length)) % array.Length;
            else return index % array.Length;
        }

        public bool Empty {
            get { return ElementCount == 0; }
        }

        public bool Full {
            get { return ElementCount == array.Length; }
        }
    }
}
