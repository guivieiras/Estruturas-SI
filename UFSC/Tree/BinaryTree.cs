﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree {
    class BinaryTree<T> where T : IComparable {

        private BinaryTreeElement<T> root;
        private BinaryTreeElement<T> first;
        private BinaryTreeElement<T> last;

        public static void Test() {
            BinaryTree<int> tree = new BinaryTree<int>();

            // tree.Add(1, 5, 7, 2, 3, 8);
            tree.Add(4, 2, 6, 1, 3, 5, 7);

            BinaryTree<string> tree2 = new BinaryTree<string>();
            tree2.Add("d", "b", "f", "a", "c", "e", "g");

            BinaryTree<int> tree3 = new BinaryTree<int>();
            List<int> varios = new List<int>();

            Random rnd = new Random();
            for (int i = 0; i < 10000; i++) {
                int a = rnd.Next(0, 1000000);
                if (!varios.Contains(a))
                    varios.Add(a);
            }

            //  tree3.Add(7, 1, 9, 0, 3, 8, 10, 2, 5, 4, 6);
            tree3.Add(varios);

            Console.WriteLine(string.Join(", ", tree.InOrder()));
            Console.WriteLine(string.Join(", ", tree2.InOrder()));




            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
            s.Start();

            string xxa = string.Join(", ", tree3.InOrder());

            s.Stop();
            Console.WriteLine(s.Elapsed);

            s.Restart();
            string xa = string.Join(", ", tree3.WEIUQHI());
            s.Stop();
            Console.WriteLine(s.Elapsed);

            s.Restart();
            tree3.dwa();
            string xbaa = string.Join(", ", tree3.x);
            s.Stop();
            Console.WriteLine(s.Elapsed);
        }

        public void Add(params T[] value) {
            foreach (var v in value)
                Add(v);

            //  inOrderPrint(root);
        }
        public void Add(IEnumerable<T> value) {
            foreach (var v in value)
                Add(v);
        }

        public IEnumerable<T> WEIUQHI() {
            return inOrderPrint(first);
        }
        public void dwa() {
            inOrderPrint2(first);
        }
        public List<T> x = new List<T>();
        public void inOrderPrint2(BinaryTreeElement<T> iterator) {
            //traverse left if exists
            if (iterator.Left != null) inOrderPrint2(iterator.Left);   
            //record root
            x.Add(iterator.Value);
            //traverse right if exists
            if (iterator.Right != null) inOrderPrint2(iterator.Right); 
        }

        public IEnumerable<T> inOrderPrint(BinaryTreeElement<T> iterator) {
            if (iterator.Left != null)
                foreach (var x in inOrderPrint(iterator.Left))
                    yield return x;                                    //traverse left if exists
            yield return iterator.Value;                                 //record root
            if (iterator.Right != null)
                foreach (var x in inOrderPrint(iterator.Right))
                    yield return x;

            //traverse right if exists
        }

        public void Add(T value) {
            BinaryTreeElement<T> element = new BinaryTreeElement<T>(value);

            if (root == null) {
                root = element;
                first = element;
                last = element;
                return;
            }

            var iterator = root;

            while (true) {

                if (iterator.Value.CompareTo(value) == 1) {
                    if (iterator.Left != null)
                        iterator = iterator.Left;
                    else {
                        iterator.Left = element;
                        element.Parent = iterator;
                        if (element.Value.CompareTo(first.Value) == -1)
                            first = element;
                        break;
                    }
                } else if (iterator.Value.CompareTo(value) == -1) {
                    if (iterator.Right != null)
                        iterator = iterator.Right;
                    else {
                        iterator.Right = element;
                        element.Parent = iterator;
                        if (element.Value.CompareTo(last.Value) == 1)
                            last = element;
                        break;
                    }
                }
            }
        }

        public IEnumerable<T> InOrder() {
            BinaryTreeElement<T> iterator = first;
            T lastReturned = default(T);
            bool firstIterate = true;

            while (true) {
                if (firstIterate || lastReturned.CompareTo(iterator.Value) == -1 && (iterator.Left == null || lastReturned.CompareTo(iterator.Left.Value) != -1)) {
                    yield return iterator.Value;
                    lastReturned = iterator.Value;
                    firstIterate = false;
                    if (iterator == last)
                        break;
                }

                if (iterator.Left == null && iterator.Right == null) {
                    iterator = iterator.Parent;
                } else if (iterator.Left != null && lastReturned.CompareTo(iterator.Left.Value) != 1) {
                    iterator = iterator.Left;
                } else if (iterator.Right != null && lastReturned.CompareTo(iterator.Right.Value) == -1) {
                    iterator = iterator.Right;
                } else iterator = iterator.Parent;
            }

        }

        public IEnumerable<T> PreOrder() { // R E D
            return null;
        }
        public IEnumerable<T> PosOrder() { // E D R
            return null;
        }
    }
}