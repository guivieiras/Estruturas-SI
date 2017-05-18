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
    class AvidBinaryTree<T> : BinaryTree<T> where T : IComparable
    {

        private BinaryTreeElement<T> root;

        private int count;

        public static new void Test()
        {
            AvidBinaryTree<int> tree = new AvidBinaryTree<int>();
            Random rnd = new Random();
            int[] varios = new int[10000];
            for (int i = 0; i < 10000; i++)
            {
                int a = rnd.Next(0, 1000000);
                varios[i] = a;
            }

            tree.Add(varios);


            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();

            s.Start();
            string xxa = string.Join(", ", tree.InOrder());
            s.Stop();
            Console.WriteLine("InOrder:".MetricJoin(s.Elapsed.ToString(), 19));

            AvidBinaryTree<int> tree2 = new AvidBinaryTree<int>();
            tree2.RecursiveAdd(4, 6, 2, 1, 3, 5, 7);

            AvidBinaryTree<int> tree3 = new AvidBinaryTree<int>();
            tree3.RecursiveAdd(5, 6, 3, 4, 2, 7);

            tree3 = new AvidBinaryTree<int>();
            tree3.RecursiveAdd(3, 2, 4, 1, 5,0);
        }



        public new void Add(params T[] value)
        {
            foreach (var v in value)
            {
                if (!Contains(v))
                    Add(v);
            }
        }
        public new void Add(IEnumerable<T> value)
        {
            foreach (var v in value)
                Add(v);
        }

        public new void RecursiveAdd(params T[] value)
        {
            foreach (var x in value)
            {
                if (root == null)
                {
                    BinaryTreeElement<T> el = new BinaryTreeElement<T>(x);
                    root = el;
                    count++;
                }
                else
                {
                    var xz = base.RecursiveAdd(root, x);
                    count++;

                    FixAvid(xz);
                }
            }

        }

        private void FixAvid(BinaryTreeElement<T> added)
        {
            if (GetHeigth(added) > getMaxHeight)
            {
                if (added == added.Parent.Left)
                {

                }
                if (added == added.Parent.Right)
                {

                }
            }
        }

        public int getMaxHeight {
            get {
                int maxCount = 3;
                int maxHeight = 1;
                while (maxCount < count)
                {
                    maxCount = maxCount * 2 + 1;
                    maxHeight++;
                }
                return maxHeight;
            }
        }

        public new void Add(T value)
        {
            base.Add(value);
        }
    }
}
