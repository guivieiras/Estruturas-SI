using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array {
    public class SAI<T> {

        public static void Test() {
            SAI<int> sai = new SAI<int>(5, 10);

            sai[5] = 5;

            sai[9] = 90;

            sai[10] = 29031;
        }

        
        private T[] array;
        private int inf, sup;
        public SAI(int inf, int sup) {
            this.inf = Math.Min(inf, sup);
            this.sup = Math.Max(inf, sup);

            array = new T[this.sup - this.inf + 1];
        }

        public T this[int indice] {
            get {
                if (indice < inf || indice > sup) throw new Exception();
                return array[indice - inf];
            }
            set {
                if (indice < inf || indice > sup) throw new Exception();
                array[indice - inf] = value;
            }
        }

    }
    
}
