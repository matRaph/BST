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
        
        private void updateBF(AVLNode node, bool isInsert)
        {                
            AVLNode parent = (AVLNode)node.Parent;
            if (parent == null)
            {
                return;
            }
            else
            {
                if (isInsert){
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
                        updateBF(parent, true);
                    }
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
                        updateBF(parent, false);
                    }
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