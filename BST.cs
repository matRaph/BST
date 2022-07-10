using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    internal class BST
    {
        internal class Node
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
            public void addLeftChild(object element)
            {
                Node node = new(this,element);
                this.LeftChild = node;
            }
            public void addRightChild(object element)
            {
                Node node = new(this, element);
                this.RightChild = node;
            }

        }

        public Node Root { get; set; }

        public ArrayList? Children { get; set; }
        public int Size{ get; set; }
        public BST(object rootElem)
        {
            Node newnode = new(null, rootElem);
            this.Root = newnode;
            this.Size = 1;
        }
        //Métodos de árvore binária


        //Métodos genéricos:

        //retorna o número de nós da árvore
        public int size() { return this.Size; }
        //retorna a altura da árvore
        public int height() { return noHeight(this.Root); }
        //retorna a altura do nó
        private int noHeight(Node node)
        {
            if (node.isExternal()) { return 0; }
            else
            {
                int hLeft = 0;
                int hRight = 0;

                if (node.hasLeft())
                {
                    hLeft = noHeight(node.LeftChild);
                }

                if (node.hasRight())
                {
                    hRight = noHeight(node.RightChild);
                }
                return Math.Max(hLeft, hRight) + 1;
            }
        }

        //Métodos de consulta
        private bool isRoot(Node node)
        {
            return node == this.Root;
        }
        private bool isInternal(Node node)
        {
            return (node.LeftChild != null) || (node.RightChild != null);
        }
        private bool isExternal(Node node)
        {
            return (node.LeftChild == null) && (node.RightChild == null);
        }
    }
}
