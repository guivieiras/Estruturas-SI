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
            string xxa = string.Join(", ", tree.RecursiveInOrder());
            s.Stop();
            Console.WriteLine("InOrder:".MetricJoin(s.Elapsed.ToString(), 19));

            AVLTree<int> tree2 = new AVLTree<int>();
            //  tree2.RecursiveAdd(4, 6, 2, 1, 3, 5, 7);

            AVLTree<int> tree3 = new AVLTree<int>();
            //tree3.RecursiveAdd(5, 6, 2, 1, 3, 0); //Deu boa pra direita
            //tree3.RecursiveAdd(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11); //Deu boa  tree3.RecursiveAdd(12); 

            //tree.RecursiveAdd(42, 88, 15, 6, 27,34); //Dupla pra direita deu boa

            //tree.RecursiveAdd(42, 15, 88, 67, 94, 51); //Dupla pra esquerda deu boa

            tree.RecursiveAdd(8, 10, 4, 2, 6, 9, 1, 3, 5, 7);
            tree.Remove(9);

            //Testar para esquerda
        }
        public void Remove(T value)
        {
            if (root == null)
                throw new Exception();
            Remove(root, value);
        }

        private void Remove(BinaryTreeElement<T> iterator, T value)
        {
            if (iterator.Value.Equals(value))
                Remove(iterator);
            else
            if (iterator.Value.CompareTo(value) == 1)

                if (iterator.Left != null)
                {
                    Remove(iterator.Left, value);
                }
                else throw new Exception();

            else
            if (iterator.Value.CompareTo(value) == -1)
                if (iterator.Right != null)
                {
                    Remove(iterator.Right, value);
                }
                else throw new Exception();

            if (recalcHeigth)
                TryRotate(iterator, true);
        }

        private void Remove(BinaryTreeElement<T> element)
        {
            var highest = getHighest(element);
            element.Value = highest.Value;

            if (highest.Parent.Right == highest)
                highest.Parent.Right = null;
            if (highest.Parent.Left == highest)
                highest.Parent.Left = null;
        }

        private BinaryTreeElement<T> getHighest(BinaryTreeElement<T> root)
        {
            if (root.Right != null) return getHighest(root.Right);
            return root;
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
        public void TryRotate(BinaryTreeElement<T> itr, bool isRemoving = false)
        {
            if (child.Height == itr.Height && !isRemoving)
                itr.Height++;

            if (itr.Left != null && itr.Height - itr.Left.Height > 2 || (itr.Left == null && itr.Height > 2))
            {
                if (isRemoving)
                {
                    itr.Height++;
                    itr.Right.Height++;
                }
                else
                if (added.CompareTo(itr.Right.Value) == -1)
                {
                    itr.Right.Height++;
                    itr.Right.Left.Height++;
                    RotateRight(itr.Right);
                }

                RotateLeft(itr);
            } else

            if (itr.Right != null && itr.Height - itr.Right.Height > 2 || (itr.Right == null && itr.Height > 2))
            {
                if (isRemoving)
                {
                    itr.Height++;
                    itr.Left.Height++;
                }
                else
                if (added.CompareTo(itr.Left.Value) == 1)
                {
                    itr.Left.Height++;
                    itr.Left.Right.Height++;
                    RotateLeft(itr.Left);
                }

                RotateRight(itr);
            }else if (isRemoving)
            {
                itr.Height--;
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
    }
}
