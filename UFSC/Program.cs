using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
using UFSC.Trabalho02;
using UFSC.Tree;

namespace Tests {
    class Program {
        public static void Main(string[] args) {
            // SimpleArrayLinkedList.Test();
            // ArrayLinkedList<string>.Test();
            //   AVLTree<int>.Test();
            //BTree.Test();
            //Multilist.Test();
            Game game = new Game();
            game.ShowMainScreen();
            Console.ReadKey();
        }
    }



}
