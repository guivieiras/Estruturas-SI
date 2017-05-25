using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFSC.Tree
{
    class Node : IDescendente
    {
        public enum ChildType
        {
            Element, Node
        }

        public ChildType childType = ChildType.Element;

        public Node Parent { get; set; }
        public int Count {
            get {
                return Keys.Count;
            }
        }

        public Node nextNode(int value)
        {
            foreach(Key key in Keys)
            {
                if (key.Value > value)
                    return key.Left as Node;

                if (key == Keys.Last())
                    return key.Right as Node;
            }
            return null;
        }

        private List<Key> Keys = new List<Key>();

        private void AddKey(Key key)
        {
            Keys.Add(key);
            Keys.Sort();
        }

        private Key Left(Key center)
        {
            int index = Keys.IndexOf(center) - 1;
            if (index >= Count || index < 0)
                return null;
            else return Keys[index];
        }
        private Key Right(Key center)
        {
            int index = Keys.IndexOf(center) + 1;
            if (index >= Count || index < 0)
                return null;
            else return Keys[index];
        }

        public void AddValue(int value)
        {
            Key key = new Key(value);
            AddKey(key);

            Element el = new Element(value);

            Key left = Left(key);
            Key right = Right(key);
            if (left != null && right != null)
            {
                left.Right = el;
                key.Left = el;

                key.Right= right.Left;
            }
            if (left != null && right == null)
            {
                if (left.First)
                {
                    left.Right = el;

                    Keys.Remove(key);
                }
                else
                {
                    key.Value = ((Element)left.Right).Value;
                    key.Left = left.Right;
                    key.Right = el;
                }
            }
            if (left == null && right != null)
            {
                if (right.First)
                {
                    right.Value = el.Value;
                    right.Right = right.Left;
                    right.Left = el;

                    Keys.Remove(key);
                }
                else
                {
                    key.Right = right.Left;
                    key.Left = el;
                }
            }
            if (left == null && right == null)
            {
                key.Left = el;
            }
        }

        public void Split()
        {
            int upRising = Count % 2 == 0 ? (Count / 2) - 1 : Count / 2;
            Key newParent = Keys[upRising];
            if (Parent == null)
            {
                Node parent = new Node();
                parent.childType = ChildType.Node;
                parent.AddKey(newParent);
            }
            else
            {
                Parent.AddKey(newParent);
            }
            Node splitRight = new Node();
            splitRight.childType = childType;
            Keys.RemoveAt(upRising);

            for (int i = upRising; i < Count; )
            {
                splitRight.AddKey(Keys[i]);
                Keys.RemoveAt(i);
            }

        }


    }

}
