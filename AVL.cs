using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace BST
{  
    public class AVL : BST{
        public AVL (object element) : base(element) { 
            this.Root = new AVLNode(null, element);
            this.Size = 1;
        }

        public override void Insert(object element)
        {
            //O pai do novo nó
            AVLNode parent = null;
            AVLNode auxNode = (AVLNode)this.Root;
            AVLNode insertedNode = new AVLNode(null, element);

            while (auxNode != null)
            {
                parent = auxNode;
                //Se elemento novo for menor que nó atual
                if (Comparer.comparer(element, auxNode.Element) == -1)
                {
                    auxNode = (AVLNode)auxNode.LeftChild;
                }
                //Se elemento novo for maior ou igual ao nó atual
                else
                {
                    auxNode = (AVLNode)auxNode.RightChild;
                }
            }

            // Se novo valor é menor que o do seu pai
            if (Comparer.comparer(element, parent.Element) == -1)
            {
                parent.LeftChild = new AVLNode(parent, element);
                insertedNode = (AVLNode)parent.LeftChild;
            }
            //Se novo valor é maior ou igual o do seu pai
            else
            {
                parent.RightChild = new AVLNode(parent, element);
                insertedNode = (AVLNode)parent.RightChild;
            }

            this.Size++;
            this.updateBFInsert(insertedNode);
        }

        public override void Remove(object element)
        {
            treeRemove(element, this.Root);
        }
        internal override Node treeRemove(object element, Node node){
            return (AVLNode)base.treeRemove(element, node);
        }
        // public override AVLNode treeRemove(object element, AVLNode node)
        // {
        //     //Caso base
        //     if (node == null) { return node; }

        //     //Chegar até o nó a ser removido
        //     if (Comparer.comparer(element, node.Element) == -1)
        //     {
        //         node.LeftChild = (AVLNode)treeRemove(element, node.LeftChild);
        //     }

        //     else if (Comparer.comparer(element, node.Element) == 1)
        //     {
        //         node.RightChild = (AVLNode)treeRemove(element, node.RightChild);
        //     }

        //     //Remove, de fato, o nó
        //     else
        //     {
        //         //Se possuir apenas o filho à direita
        //         if (!node.hasLeft())
        //         {
        //             node.Parent = null;
        //             return (AVLNode)node.RightChild;
        //         }

        //         //Se possuir apenas o filho à esquerda
        //         else if (!node.hasRight())
        //         {
        //             node.Parent = null;
        //             return (AVLNode)node.LeftChild;
        //         }

        //         //Se possuir os dois filhos
        //         else
        //         {
        //             AVLNode successor = (AVLNode)min(node.RightChild);
        //             node.Element = successor.Element;
        //             node.RightChild = (AVLNode)treeRemove(successor.Element, node.RightChild);
        //         }
        //     }

        //     return node;
        // }

        private void updateBFInsert(AVLNode node)
        {                
            AVLNode parent = (AVLNode)node.Parent;
            if (parent == null)
            {
                return;
            }
            else
            {
                if (parent.LeftChild == node)
                {   
                    parent.BalanceFactor--;
                }
                else
                {
                    parent.BalanceFactor++;
                }
                if (parent.BalanceFactor != 0)
                {
                    updateBFInsert(parent);
                }
            }
        }
        private void updateBFRemove(AVLNode node)
        {
            AVLNode parent = (AVLNode)node.Parent;
            if (parent == null)
            {
                return;
            }
            else
            {
                if (parent.LeftChild == node)
                {
                    parent.BalanceFactor++;
                }
                else
                {
                    parent.BalanceFactor--;
                }
                if (parent.BalanceFactor != 0)
                {
                    updateBFRemove(parent);
                }
            }
        }
    }
}