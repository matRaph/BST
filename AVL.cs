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
            }
            //Se novo valor é maior ou igual o do seu pai
            else
            {
                parent.RightChild = new AVLNode(parent, element);
            }

            this.Size++;
            // this.updateBalanceFactor();
        }

        private void updateBFInsert(AVLNode node)
        {
            if (node.Parent == null)
            {
                return;
            }
            else
            {
                AVLNode parent = (AVLNode)node.Parent;
                if (node.Parent.LeftChild == node)
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
    }
}