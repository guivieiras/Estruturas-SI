using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {
    class Program {
        public static void Main(string[] args) {
            SimpleArrayLinkedList.Test();
            ArrayLinkedList<string>.Test();
         //   BinaryTree<int>.Test();
            Console.ReadKey();
        }
    }



}
