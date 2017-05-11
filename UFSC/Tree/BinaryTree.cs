using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFSC.Extension;

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


            Console.WriteLine();

            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();

            s.Start();
            string xxa = string.Join(", ", tree3.InOrder());
            s.Stop();
            Console.WriteLine("InOrder:".MetricJoin(s.Elapsed.ToString(), 19));

            s.Restart();
            string xa = string.Join(", ", tree3.RecursiveInOrder());
            s.Stop();
            Console.WriteLine("RecursiveInOrder:".MetricJoin(s.Elapsed.ToString(), 19));

            s.Restart();
            tree3.PrintInOrder1();
            string xbaa = string.Join(", ", tree3.x);
            s.Stop();
            Console.WriteLine("Print int order 1:".MetricJoin(s.Elapsed.ToString(), 19));


            BinaryTree<int> tre = new BinaryTree<int>();
            //tre.RecursiveAdd(5, 1, 4, 9, 2, 3, 8, 6, 7);


            s.Restart();
            tree3.PrintInOrder2();
            string ax = string.Join(", ", tree3.z);
            s.Stop();
            Console.WriteLine("Print int order 2:".MetricJoin(s.Elapsed.ToString(), 19));

        }

        public void Add(params T[] value) {
            foreach (var v in value)
                Add(v);
        }
        public void Add(IEnumerable<T> value) {
            foreach (var v in value)
                Add(v);
        }

        public void RecursiveAdd(params T[] value) {
            foreach (var x in value) {
                if (first == null) {
                    BinaryTreeElement<T> el = new BinaryTreeElement<T>(x);
                    first = el;
                    root = el;

                } else
                    RecursiveAdd(root, x);
            }
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

        private void RecursiveAdd(BinaryTreeElement<T> previous, T value) {
            if (value.CompareTo(previous.Value) == -1) {
                if (previous.Left == null) {
                    BinaryTreeElement<T> el = new BinaryTreeElement<T>(value);
                    previous.Left = el;
                    el.Parent = previous;
                    if (first.Value.CompareTo(value) == 1)
                        first = el;

                } else {
                    RecursiveAdd(previous.Left, value);
                }
            }
            if (value.CompareTo(previous.Value) == 1) {
                if (previous.Right == null) {
                    BinaryTreeElement<T> el = new BinaryTreeElement<T>(value);
                    previous.Right = el;
                    el.Parent = previous;
                } else {
                    RecursiveAdd(previous.Right, value);
                }
            }
        }

        public void PrintInOrder1() {
            PrintInOrder1(root);
        }
        public void PrintInOrder2() {
            PrintInOrder2(root);
        }
        public IEnumerable<T> RecursiveInOrder() {
            return RecursiveInOrder(root);
        }

        public List<T> x = new List<T>();
        public List<T> z = new List<T>();
        public void PrintInOrder1(BinaryTreeElement<T> iterator) {
            if (iterator.Left != null) PrintInOrder1(iterator.Left);
            x.Add(iterator.Value);
            if (iterator.Right != null) PrintInOrder1(iterator.Right);
        }

        private void PrintInOrder2(BinaryTreeElement<T> previous) {
            if (previous.Left != null) PrintInOrder2(previous.Left);
            z.Add(previous.Value);
            if (previous.Right != null) PrintInOrder2(previous.Right);
        }
  

        public IEnumerable<T> RecursiveInOrder(BinaryTreeElement<T> iterator) {
            if (iterator.Left != null)
                foreach (var x in RecursiveInOrder(iterator.Left))
                    yield return x;                                   
            yield return iterator.Value;                                 
            if (iterator.Right != null)
                foreach (var x in RecursiveInOrder(iterator.Right))
                    yield return x;

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
