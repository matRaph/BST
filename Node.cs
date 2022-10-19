using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST{
    public class Node
        {
            public object Element { get; set; }
            public Node? Parent { get; set; }
            public Node? LeftChild { get; set; }
            public Node? RightChild { get; set; }
            public ArrayList Children { get; set; }
            public Node(Node parent, object element)
            {
                this.Parent = parent;
                this.Element = element;
            }
            public override string ToString() => Element.ToString();

            //Métodos de consulta
            public bool isInternal() {
                return (this.LeftChild != null) || (this.RightChild != null);
            }
            public bool isExternal()
            {
                return (this.LeftChild == null) && (this.RightChild == null);
            }
            public bool hasLeft() { return this.LeftChild != null; }
            public bool hasRight() { return this.RightChild != null; }
            public Node leftChild() { return this.LeftChild; }
            public Node rightChild() { return this.RightChild; }

            //Métodos de manipulação
            public virtual void addLeftChild(object element)
            {
                this.LeftChild = new(this, element);
            }
            public virtual void addRightChild(object element)
            {
                this.RightChild = new(this, element);
            }

        }
}