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
    class AVLTree<T> : BinaryTree<T> where T : IComparable
    {

        private BinaryTreeElement<T> root;

        public static new void Test()
        {
            AVLTree<int> tree = new AVLTree<int>();
            Random rnd = new Random();
            int[] varios = new int[100];
            for (int i = 0; i < 100; i++)
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

            AVLTree<int> tree2 = new AVLTree<int>();
            //  tree2.RecursiveAdd(4, 6, 2, 1, 3, 5, 7);

            AVLTree<int> tree3 = new AVLTree<int>();
            //tree3.RecursiveAdd(5, 6, 2, 1, 3, 0); //Deu boa pra direita
            //tree3.RecursiveAdd(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11); //Deu boa  tree3.RecursiveAdd(12); 

            tree.RecursiveAdd(42, 88, 15, 6, 27,34); //Dupla pra direita

            //Testar para esquerda
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

        bool recalcHeigth = true;
        internal new void RecursiveAdd(BinaryTreeElement<T> previous, T value)
        {
            BinaryTreeElement<T> el = new BinaryTreeElement<T>(value);
            if (value.CompareTo(previous.Value) == -1)
            {
                if (previous.Left == null)
                {
                    previous.Left = el;
                    el.Parent = previous;
                    Console.WriteLine(value);
                    added = el.Value;
                    child = el;
                }
                else
                {
                    RecursiveAdd(previous.Left, value);
                }
            }
            if (value.CompareTo(previous.Value) == 1)
            {
                if (previous.Right == null)
                {
                    previous.Right = el;
                    el.Parent = previous;
                    Console.WriteLine(value);
                    added = el.Value;
                    child = el;
                }
                else
                {
                    RecursiveAdd(previous.Right, value);

                }
            }
            if (recalcHeigth)
            {
                Console.WriteLine("Voltando:" + previous.Value);
                TryRotate(previous);
            }
        }

        private BinaryTreeElement<T> child;
        private T added;
        public void TryRotate(BinaryTreeElement<T> itr)
        {
            if (child.Height == itr.Height)
                itr.Height++;

            if (itr.Left != null && itr.Height - itr.Left.Height > 2 || (itr.Left == null && itr.Height > 2))
            {
                if (added.CompareTo(itr.Right.Value) == -1)
                {
                    itr.Right.Height++;
                    itr.Right.Left.Height++;
                    RotateRight(itr.Right);
                }

                RotateLeft(itr);
            }
            if (itr.Right != null && itr.Height - itr.Right.Height > 2 || (itr.Right == null && itr.Height > 2))
            {
                if (added.CompareTo(itr.Left.Value) == 1)
                {
                    itr.Left.Height++;
                    itr.Left.Right.Height++;
                    RotateLeft(itr.Left);
                }

                RotateRight(itr);
            }

            child = itr;
        }

        private void RotateLeft(BinaryTreeElement<T> itr)
        {
            var direita = itr.Right;

            recalcHeigth = false;
            itr.Height--;
            itr.Height--;

            if (itr == root)
            {
                root = direita;
                direita.Parent = null;
            }
            else
            if (itr.Parent.Left != null & itr.Parent.Left == itr)
            {
                itr.Parent.Left = direita;
                direita.Parent = itr.Parent;
            }
            else
            if (itr.Parent.Right != null && itr.Parent.Right == itr)
            {
                itr.Parent.Right = direita;
                direita.Parent = itr.Parent;
            }
            itr.Right = direita.Left;
            itr.Parent = direita;

            if (direita.Left != null)
                direita.Left.Parent = itr;

            direita.Left = itr;
        }

        private void RotateRight(BinaryTreeElement<T> itr)
        {
            var esquerda = itr.Left;

            recalcHeigth = false;
            itr.Height--;
            itr.Height--;

            if (itr == root)
            {
                root = esquerda;
                esquerda.Parent = null;
            }
            else
            if (itr.Parent.Left != null & itr.Parent.Left == itr)
            {
                itr.Parent.Left = esquerda;
                esquerda.Parent = itr.Parent;
            }
            else
            if (itr.Parent.Right != null && itr.Parent.Right == itr)
            {
                itr.Parent.Right = esquerda;
                esquerda.Parent = itr.Parent;
            }
            itr.Left = esquerda.Right;
            itr.Parent = esquerda;

            if (esquerda.Right != null)
                esquerda.Right.Parent = itr;
            esquerda.Right = itr;
        }

        public new void RecursiveAdd(params T[] value)
        {
            foreach (var x in value)
            {
                if (root == null)
                {
                    BinaryTreeElement<T> el = new BinaryTreeElement<T>(x);
                    root = el;
                }
                else
                {
                    recalcHeigth = true;
                    RecursiveAdd(root, x);
                }
            }

        }

        public new void Add(T value)
        {
            base.Add(value);
        }
    }
}
