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
            this.updateBF(insertedNode, true);
        }

        public override void Remove(object element)
        {
            updateBF((AVLNode)treeRemove(element, this.Root), false);
        }
        internal override Node treeRemove(object element, Node node){
            return (AVLNode)base.treeRemove(element, node);
        }
        
        private void updateBF(AVLNode node, bool isInsert)
        {                
            AVLNode parent = (AVLNode)node.Parent;
            if (node.BalanceFactor >= 2 || node.BalanceFactor <= -2)
            {
                if (node.BalanceFactor > 0)
                {
                    AVLNode lChil = (AVLNode)node.LeftChild;
                    if (lChil.BalanceFactor >= 0)
                    {
                        this.rotateRight(node);
                    }
                    else
                    {
                        this.rotateLeft((AVLNode)node.LeftChild);
                        this.rotateRight(node);
                    }
                }
                else
                {
                    AVLNode rChil = (AVLNode)node.RightChild;
                    if (rChil.BalanceFactor <= 0)
                    {
                        this.rotateLeft(node);
                    }
                    else
                    {
                        this.rotateRight((AVLNode)node.RightChild);
                        this.rotateLeft(node);
                    }
                }
            }
            if (parent == null)
            {
                return;
            }
            else
            {
                if (isInsert){
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
                        updateBF(parent, true);
                    }

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
                        updateBF(parent, false);
                    }
                }
            }
                
        }
        
        private void rotateLeft(AVLNode node){
            AVLNode parent = (AVLNode)node.Parent;
            AVLNode rChild = (AVLNode)node.RightChild;
            AVLNode rlChild = (AVLNode)rChild.LeftChild;
            if (parent == null)
            {
                this.Root = rChild;
                rChild.Parent = null;
            }
            else
            {
                if (parent.LeftChild == node)
                {
                    parent.LeftChild = rChild;
                }
                else
                {
                    parent.RightChild = rChild;
                }
                rChild.Parent = parent;
            }
            node.RightChild = rlChild;
            if (rlChild != null)
            {
                rlChild.Parent = node;
            }
            rChild.LeftChild = node;
            node.Parent = rChild;
            int newBB = node.BalanceFactor + 1 - Math.Min(rChild.BalanceFactor, 0);
            int newAB = rChild.BalanceFactor + 1 + Math.Max(newBB, 0);
            node.BalanceFactor = newBB;
            rChild.BalanceFactor = newAB;
        }

        private void rotateRight(AVLNode node){
            AVLNode parent = (AVLNode)node.Parent;
            AVLNode lChild = (AVLNode)node.LeftChild;
            AVLNode lrChild = (AVLNode)lChild.RightChild;
            if (parent == null)
            {
                this.Root = lChild;
                lChild.Parent = null;
            }
            else
            {
                if (parent.LeftChild == node)
                {
                    parent.LeftChild = lChild;
                }
                else
                {
                    parent.RightChild = lChild;
                }
                lChild.Parent = parent;
            }
            node.LeftChild = lrChild;
            if (lrChild != null)
            {
                lrChild.Parent = node;
            }
            lChild.RightChild = node;
            node.Parent = lChild;
            int newB_FB = node.BalanceFactor - 1 - Math.Max(lChild.BalanceFactor, 0);
            int newA_FB = lChild.BalanceFactor - 1 + Math.Min(newB_FB, 0);
            node.BalanceFactor = newB_FB;
            lChild.BalanceFactor = newA_FB;
        }
    }
}