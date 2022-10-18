using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
namespace BST
{
    public class AVL:BST
    {
        public AVL(object rootElem) : base(rootElem) { }       
        public class AVLNode : BST.Node
        {
            public int BalanceFactor { get; set; }
            public AVLNode(Node parent, object element) : base(parent, element)
            {
                this.BalanceFactor = 0;
            }
            public override string ToString() => $"{Element}({BalanceFactor})";
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
            //Se novo valor é menor que o do seu pai
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
            //Atualiza o fator de balanceamento
            updateBalanceFactor(parent);
        }
        
        private void updateBalanceFactor(AVLNode node){
            if(node == null) return;
            //Atualiza o fator de balanceamento
            node.BalanceFactor = noHeight((AVLNode)node.LeftChild) - noHeight((AVLNode)node.RightChild);
            //Se o fator de balanceamento for -2 ou 2, então a árvore está desbalanceada
            if(node.BalanceFactor == -2){
                //Se o filho direito está desbalanceado para a esquerda
                if(((AVLNode)node.RightChild).BalanceFactor == 1){
                    //Rotação dupla
                    // rotateRight((AVLNode)node.RightChild);
                    // rotateLeft(node);
                }
                //Se o filho direito está desbalanceado para a direita
                else{
                    //Rotação simples
                    // rotateLeft(node);
                }
            }
            else if(node.BalanceFactor == 2){
                //Se o filho esquerdo está desbalanceado para a direita
                if(((AVLNode)node.LeftChild).BalanceFactor == -1){
                    //Rotação dupla
                    // rotateLeft((AVLNode)node.LeftChild);
                    // rotateRight(node);
                }
                //Se o filho esquerdo está desbalanceado para a esquerda
                else{
                    //Rotação simples
                    // rotateRight(node);
                }
            }
            //Se o fator de balanceamento não for -2 ou 2, então a árvore está balanceada
            else{
                //Atualiza o fator de balanceamento do pai
                updateBalanceFactor((AVLNode)node.Parent);
            }
        }
    }
}