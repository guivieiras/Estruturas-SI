using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFSC.Extension;
using System.Threading;

namespace Tree
{
    class BinaryTree<T> where T : IComparable
    {

        private BinaryTreeElement<T> root;
        private BinaryTreeElement<T> first;
        private BinaryTreeElement<T> last;

        public static void Test()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            // tree.Add(1, 5, 7, 2, 3, 8);
            tree.Add(4, 2, 6, 1, 3, 5, 7);

            BinaryTree<string> tree2 = new BinaryTree<string>();
            tree2.Add("d", "b", "f", "a", "c", "e", "g");

            BinaryTree<int> tree3 = new BinaryTree<int>();

            Random rnd = new Random();
            int[] varios = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                int a = rnd.Next(0, 1000000);
                varios[i] = a;
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
            Thread.Sleep(100);

            s.Restart();
            string xa = string.Join(", ", tree3.RecursiveInOrder());
            s.Stop();
            Console.WriteLine("RecursiveInOrder:".MetricJoin(s.Elapsed.ToString(), 19));
            Thread.Sleep(100);

            s.Restart();
            tree3.PrintInOrder2();
            string xbaa = string.Join(", ", tree3.z);
            s.Stop();
            Console.WriteLine("Print in order 2:".MetricJoin(s.Elapsed.ToString(), 19));

            tree3.z.Clear();
            //  BinaryTree<int> tre = new BinaryTree<int>();
            //tre.RecursiveAdd(5, 1, 4, 9, 2, 3, 8, 6, 7);
            Thread.Sleep(100);


            s.Restart();
            tree3.PrintInOrder2();
            string ax = string.Join(", ", tree3.z);
            s.Stop();
            Console.WriteLine("Print in order 2:".MetricJoin(s.Elapsed.ToString(), 19));

            tree3.x.Clear();
            GC.Collect();
            Thread.Sleep(100);


            s.Restart();
            tree3.PrintInOrder1();
            string pt3 = string.Join(", ", tree3.x);
            s.Stop();
            Console.WriteLine("Print in order 1:".MetricJoin(s.Elapsed.ToString(), 19));
            Thread.Sleep(100);


            s.Restart();
            //tree3.PreOrder();
            string pt4 = string.Join(", ", tree3.PreOrder());
            s.Stop();
            Console.WriteLine("Pre order:".MetricJoin(s.Elapsed.ToString(), 19));

            //    Console.WriteLine(pt4);

            BinaryTree<string> STR = new BinaryTree<string>();
            STR.Add("F", "B", "A", "D", "C", "E", "G", "I", "H");

            //    Console.WriteLine(string.Join(", ", STR.PreOrder()));
        }

        public bool Contains(T value)
        {
            if (root == null)
                return false;
            return Contains(root, value);
        }

        private bool Contains(BinaryTreeElement<T> iterator, T value)
        {
            if (iterator.Value.Equals(value))
                return true;
            if (iterator.Value.CompareTo(value) == 1)
            {
                if (iterator.Left != null)
                {
                    return Contains(iterator.Left, value);
                }
                else return false;
            }
            else

            if (iterator.Right != null)
            {
                return Contains(iterator.Right, value);
            }
            else return false;
        }

        public void Add(params T[] value)
        {
            foreach (var v in value)
            {
                if (!Contains(v))
                    Add(v);
            }
        }
        public void Add(IEnumerable<T> value)
        {
            foreach (var v in value)
                Add(v);
        }

        public void RecursiveAdd(params T[] value)
        {
            foreach (var x in value)
            {
                if (first == null)
                {
                    BinaryTreeElement<T> el = new BinaryTreeElement<T>(x);
                    first = el;
                    root = el;

                }
                else
                    RecursiveAdd(root, x);
            }
        }

        public void Add(T value)
        {
            BinaryTreeElement<T> element = new BinaryTreeElement<T>(value);

            if (root == null)
            {
                root = element;
                first = element;
                last = element;
                return;
            }

            var iterator = root;

            while (true)
            {

                if (iterator.Value.CompareTo(value) == 1)
                {
                    if (iterator.Left != null)
                        iterator = iterator.Left;
                    else
                    {
                        iterator.Left = element;
                        element.Parent = iterator;
                        if (element.Value.CompareTo(first.Value) == -1)
                            first = element;
                        break;
                    }
                }
                else if (iterator.Value.CompareTo(value) == -1)
                {
                    if (iterator.Right != null)
                        iterator = iterator.Right;
                    else
                    {
                        iterator.Right = element;
                        element.Parent = iterator;
                        if (element.Value.CompareTo(last.Value) == 1)
                            last = element;
                        break;
                    }
                }
            }
        }

        internal int GetHeigth(BinaryTreeElement<T> element)
        {
            int h = 0;
            while (element.Parent != null)
            {
                element = element.Parent;
                h++;
            }
            return h;
        }

        internal BinaryTreeElement<T> RecursiveAdd(BinaryTreeElement<T> previous, T value)
        {
            if (value.CompareTo(previous.Value) == -1)
            {
                if (previous.Left == null)
                {
                    BinaryTreeElement<T> el = new BinaryTreeElement<T>(value);
                    previous.Left = el;
                    el.Parent = previous;
                    if (first != null && first.Value.CompareTo(value) == 1)
                        first = el;

                    return el;
                }
                else
                {
                    return RecursiveAdd(previous.Left, value);
                }
            }
            if (value.CompareTo(previous.Value) == 1)
            {
                if (previous.Right == null)
                {
                    BinaryTreeElement<T> el = new BinaryTreeElement<T>(value);
                    previous.Right = el;
                    el.Parent = previous;

                    return el;
                }
                else
                {
                    return RecursiveAdd(previous.Right, value);
                }
            }
            return null;
        }

        public void PrintInOrder1()
        {
            PrintInOrder1(root);
        }
        public void PrintInOrder2()
        {
            PrintInOrder2(root);
        }
        public IEnumerable<T> RecursiveInOrder()
        {
            return RecursiveInOrder(root);
        }

        public List<T> x = new List<T>();
        public List<T> z = new List<T>();
        public void PrintInOrder1(BinaryTreeElement<T> iterator)
        {
            if (iterator.Left != null) PrintInOrder1(iterator.Left);
            x.Add(iterator.Value);
            if (iterator.Right != null) PrintInOrder1(iterator.Right);
        }

        private void PrintInOrder2(BinaryTreeElement<T> previous)
        {
            if (previous.Left != null) PrintInOrder2(previous.Left);
            z.Add(previous.Value);
            if (previous.Right != null) PrintInOrder2(previous.Right);
        }


        public IEnumerable<T> RecursiveInOrder(BinaryTreeElement<T> iterator)
        {
            if (iterator.Left != null)
                foreach (var x in RecursiveInOrder(iterator.Left))
                    yield return x;
            yield return iterator.Value;
            if (iterator.Right != null)
                foreach (var x in RecursiveInOrder(iterator.Right))
                    yield return x;

        }

        public IEnumerable<T> InOrder()
        {
            BinaryTreeElement<T> iterator = first;
            T lastReturned = default(T);
            bool firstIterate = true;

            while (true)
            {
                if (firstIterate || lastReturned.CompareTo(iterator.Value) == -1 && (iterator.Left == null || lastReturned.CompareTo(iterator.Left.Value) != -1))
                {
                    yield return iterator.Value;
                    lastReturned = iterator.Value;
                    firstIterate = false;
                    if (iterator == last)
                        break;
                }

                if (iterator.Left == null && iterator.Right == null)
                {
                    iterator = iterator.Parent;
                }
                else if (iterator.Left != null && lastReturned.CompareTo(iterator.Left.Value) != 1)
                {
                    iterator = iterator.Left;
                }
                else if (iterator.Right != null && lastReturned.CompareTo(iterator.Right.Value) == -1)
                {
                    iterator = iterator.Right;
                }
                else iterator = iterator.Parent;
            }

        }

        private Trabalho01.ArrayLinkedList<T> preOrderBuffer = new Trabalho01.ArrayLinkedList<T>(1000);

        public Trabalho01.ArrayLinkedList<T> PreOrder()
        {
            //preOrderBuffer.Clear();
            PreOrder(root);
            return preOrderBuffer;
        }
        private void PreOrder(BinaryTreeElement<T> iterator)
        {
            preOrderBuffer.Add(iterator.Value);
            if (iterator.Left != null) PreOrder(iterator.Left);
            if (iterator.Right != null) PreOrder(iterator.Right);
        }

        public IEnumerable<T> PosOrder()
        { // E D R
            return null;
        }
    }
}
