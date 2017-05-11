using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {
    class Linq {
        public static void Run() {



            int[] a = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 8 };
            var c = a.SelectMany((val1, j) => a.Select((val2, i) => new { v1 = val1, v2 = val2, i = i, j = j }));

            var c2 = a.SelectMany(val1 => a.Select(val2 => new { v1 = val1, v2 = val2 }));

            var c3 = a.SelectMany((val1, j) => a.Select((val2, i) => new { v1 = val1, v2 = val2, i = i, j = j }));

            var wat = new { xsda = a };


            foreach (var item in c) {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in c2) {
                Console.WriteLine(item);
            }

        }
    }
}
