using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {
    class Toptal {

        public static object[] flattened (object[] nested) {
            List<object> flat = new List<object>();

            foreach (object element in nested) {
      
                if (element  is Array) {
                    flat.AddRange( flattened(element as object[]));
                }else {
                    flat.Add(element);
                }
            }

            return flat.ToArray();
        }

        public static void ToptalTest() {
            object[] arr = { "This is a string", 1, 2, new object[] { 3 }, new object[] { 5, new object[] { 5, 6 } }, new object[] { new object[] { 7 } }, 8, "[10, 11]" };


            foreach (var element in Toptal.flattened(arr)) {
                Console.WriteLine(element);
            }

        }
    }
}



//Devise a function that accepts an arbitrarily-nested array with elements of arbitrary types, 
//    and returns a flattened version of it.Do not solve the task using a built-in function that can
//    accomplish the whole task on its own.

//Example:
//["This is a string", 1, 2, [3], [4, [5, 6]], [[7]], 8, "[10, 11]"] -> ["This is a string", 1, 2, 3, 4, 5, 6, 7, 8, "[10, 11]"]