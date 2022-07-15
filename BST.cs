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
        public object search(object element)
        {
            return noSearch(element, this.Root).Element;
        }
        private Node noSearch(object element, Node node)
        {
            if (isExternal(node)) { return node; }

            //Se elemento procurado for menor que elemento do nó
            if (comparer(element, node.Element) == -1)
            {
                return noSearch(element, node.LeftChild);
            }

            //Se elemento procurado for igual ao elemento do nó
            else if (comparer(element, node.Element) == 0)
            {
                return node;
            }

            //Se elemento procurado for maior que elemento do nó
            else
            {
                return noSearch(element, node.RightChild);
            }
        }
        public void Insert(object element)
        {
            //O pai do novo nó
            Node parent = null;
            Node auxNode = this.Root;

            while (auxNode != null)
            {
                parent = auxNode;
                //Se elemento novo for menor que nó atual
                if (comparer(element, auxNode.Element) == -1)
                {
                    auxNode = auxNode.LeftChild;
                }
                //Se elemento novo for maior ou igual ao nó atual
                else
                {
                    auxNode = auxNode.RightChild;
                }
            }
            //Se novo valor é menor que o do seu pai
            if (comparer(element, parent.Element) == -1)
            {
                parent.addLeftChild(element);
            }
            //Se novo valor é maior ou igual o do seu pai
            else
            {
                parent.addRightChild(element);
            }

            this.Size++;
        }

        public void Remove(object element)
        {
            treeRemove(element, this.Root);
        }
        private Node treeRemove(object element, Node node)
        {

            if(node == null) { return node; }

            //Chegar até o nó a ser removido
            if (comparer(element, node.Element) == -1)
            {
                node.LeftChild = treeRemove(element, node.LeftChild);
            }

            else if (comparer(element, node.Element) == 1)
            {
                node.RightChild = treeRemove(element, node.RightChild);
            }

            //Remove, de fato, o nó
            else
            {
                //Se possuir apenas o filho à direita
                if (!node.hasLeft())
                {
                    node.Parent = null;
                    return node.RightChild;
                }

                //Se possuir apenas o filho à esquerda
                else if (!node.hasRight())
                {
                    node.Parent = null;
                    return node.LeftChild;
                }

                //Se possuir os dois filhos
                else
                {
                    Node successor = min(node.RightChild);
                    node.Element = successor.Element;
                    node.RightChild = treeRemove(successor.Element, node.RightChild);
                }
            }

            return node;
        }
        //Retorna o nó com o menor elemento da subarvore de node
        private Node min(Node node)
        {
            while (node.hasLeft())
            {
                node = node.LeftChild;
            }
            return node;
        }
        public void show()
        {
            printBinaryTree(this.Root);
        }
        private void printBinaryTree(Node root)
        {
            LinkedList<Node> treeLevel = new LinkedList<Node>();
            treeLevel.AddLast(root);
            LinkedList<Node> temp = new LinkedList<Node>();
            int counter = 0;
            int height = noHeight(root);
            double numberOfElements = (Math.Pow(2, (height + 1)) - 1);
            while (counter <= height)
            {
                Node removed = treeLevel.First();
                treeLevel.RemoveFirst();
                if (temp.Count == 0)
                {
                    printSpace(numberOfElements / Math.Pow(2, counter + 1), removed);
                }
                else
                {
                    printSpace(numberOfElements / Math.Pow(2, counter), removed);
                }
                if (removed == null)
                {
                    temp.AddLast((Node)null);
                    temp.AddLast((Node)null);
                }
                else
                {
                    temp.AddLast(removed.LeftChild);
                    temp.AddLast(removed.RightChild);
                }

                if (treeLevel.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    treeLevel = temp;
                    temp = new LinkedList<Node>();
                    counter++;
                }

            }
            void printSpace(double n, Node removed)
            {
                for (; n > 0; n--)
                {
                    Console.Write(" ");
                }
                if (removed == null)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(removed.Element);
                }
            }
        }

        //Comparador
        private int comparer(object element1, object element2)
        {
            if (Convert.ToInt32(element1) == Convert.ToInt32(element2)) { return 0; }
            if (Convert.ToInt32(element1) > Convert.ToInt32(element2)) { return 1; }
            else { return -1;}
        }
    }
}
