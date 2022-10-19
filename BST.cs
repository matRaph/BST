using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class BST
    {

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
        public virtual int height() { return noHeight(this.Root); }
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
        internal int noDepth(Node node)
        {
            int depth = 0;
            Node root = this.Root;

            while (root != node)
            {
                depth++;
                if (Comparer.comparer(node.Element, root.Element) == 1)
                {
                    root = root.RightChild;
                }
                else
                {
                    root = root.LeftChild;
                }
            }
            return depth;
            
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
        internal Node noSearch(object element, Node node)
        {
            if (isExternal(node)) { return node; }

            //Se elemento procurado for menor que elemento do nó
            if (Comparer.comparer(element, node.Element) == -1)
            {
                return noSearch(element, node.LeftChild);
            }

            //Se elemento procurado for igual ao elemento do nó
            else if (Comparer.comparer(element, node.Element) == 0)
            {
                return node;
            }

            //Se elemento procurado for maior que elemento do nó
            else
            {
                return noSearch(element, node.RightChild);
            }
        }
        public virtual void Insert(object element)
        {
            //O pai do novo nó
            Node parent = null;
            Node auxNode = this.Root;

            while (auxNode != null)
            {
                parent = auxNode;
                //Se elemento novo for menor que nó atual
                if (Comparer.comparer(element, auxNode.Element) == -1)
                {
                    auxNode = auxNode.LeftChild;
                }
                //Se elemento novo for maior ou igual ao nó atual
                else
                {
                    auxNode = auxNode.RightChild;
                }
            }

            // Se novo valor é menor que o do seu pai
            if (Comparer.comparer(element, parent.Element) == -1)
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

            //Caso base
            if (node == null) { return node; }

            //Chegar até o nó a ser removido
            if (Comparer.comparer(element, node.Element) == -1)
            {
                node.LeftChild = treeRemove(element, node.LeftChild);
            }

            else if (Comparer.comparer(element, node.Element) == 1)
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
        public virtual void show()
        {
            List<Node> nodes = new List<Node>();
            printOrder(this.Root, nodes);
            printNodes(nodes);
            Console.WriteLine();
        }
        public virtual void printOrder(Node root, List<Node> nodes)
        {
            if (root == null) return;

            printOrder(root.RightChild, nodes);
            nodes.Add(root);
            printOrder(root.LeftChild, nodes);
        }
        public virtual void printNodes(List<Node> nodes)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine();
                for (int i = 0; i < noDepth(node); i++)
                {
                    Console.Write("     ");
                }
                Console.WriteLine(node); 
            }
        }
        
    }

}
