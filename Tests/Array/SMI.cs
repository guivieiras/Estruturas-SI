using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {
    public class SMI<T> {

        public static void Test() {

            SMI<int> smi = new SMI<int>(5, 10);

            smi[1, 2] = 5;
            smi[5, 10] = 5644564;

            Console.WriteLine(smi.ToString());
        }

        private T[] array;
        private int x, y;
        public SMI(int x, int y) {

            this.x = x;
            this.y = y;

            array = new T[x * y];
        }

        public T this[int x, int y] {
            get { return array[this.y * (x - 1) + y - 1]; }
            set { array[this.y * (x - 1) + y - 1] = value; }
        }

        public new string ToString() {
            string r = "";

            for (int i = 1; i <= x; i++) {
                for (int j = 1; j <= y; j++) {
                    r += array[y * (i - 1) + j - 1];
                    if (j != y) r += " , ";
                }
                r += Environment.NewLine;
            }
            return r;
        }
    }
}
