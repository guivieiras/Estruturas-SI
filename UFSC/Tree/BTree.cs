using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    public class BTree
    {

        public static void Test()
        {
            BTree bt = new BTree(5);
            bt.Add(1);
            bt.Add(5);
            bt.Add(10);
            bt.Add(15);
            bt.Add(20);
            bt.Add(25);
            bt.Add(30);
            bt.Add(25);
        }
        private Node Root;
        private int Degree;
        private int Minimum {
            get {
                if (Degree % 2 == 1)
                    return (Degree + 1) / 2;
                else return Degree / 2;
            }
        }

        public BTree(int Degree)
        {
            this.Degree = Degree;
        }

        public void Add(int value)
        {
            Key key = new Key(value);
            if (Root == null)
            {
                Root = new Node();
            }
            Add(Root, value);


        }

        private void Add(Node root, int value)
        {
            if (root.childType == Node.ChildType.Element)
            {
                root.AddValue(value);
                if (root.Count == Degree)
                    root.Split();
            }
            else Add(root.nextNode(value), value);
         }
    }
}
