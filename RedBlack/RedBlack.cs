using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST{
    public class RedBlack : BST
    {
        public RedBlack (object element) : base(element) { 
            RedBlackNode root = new(null, element);
            root.SetBlack(root);
            this.Root = root;
            this.Size = 1;
        }

        public void InsertRB(object element){
            
            //Caso 1: Árvore vazia
            //Verifica se a árvore está vazia, e caso esteja, cria um nó raiz preto
            if (this.Root == null)
            {
                this.Root = new RedBlackNode(null, element);
                this.Size++;
                return;
            }

            //Insere o nó na árvore
            RedBlackNode insertedNode = InsertTree(element);

            //Caso 2: Se o tio é vermelho, troca a cor do pai e do tio para preto e a cor do avô para vermelho,
            //e chama a função recursivamente para o avô
            if (insertedNode.Parent != null && insertedNode.Parent.Parent != null)
            {
                this.Case2(insertedNode);
                // RedBlackNode parent = (RedBlackNode)insertedNode.Parent;
                // RedBlackNode grandparent = (RedBlackNode)parent.Parent;
                // RedBlackNode uncle = (RedBlackNode)grandparent.LeftChild == parent ? (RedBlackNode)grandparent.RightChild : (RedBlackNode)grandparent.LeftChild;
                
                // if (uncle != null && uncle.Color == RedBlackNode.EnumColor.Red)
                // {
                //     parent.SetBlack();
                //     uncle.SetBlack();
                //     grandparent.SetRed();
                //     InsertRB(grandparent.Element);
                //     return;
                // }
            }
            
        }
        public RedBlackNode Case2(RedBlackNode InsetedNode){
            RedBlackNode parent = (RedBlackNode)InsetedNode.Parent;
            RedBlackNode grandparent = (RedBlackNode)parent.Parent;
            RedBlackNode uncle = (RedBlackNode)grandparent.LeftChild == parent ? (RedBlackNode)grandparent.RightChild : (RedBlackNode)grandparent.LeftChild;
            
            if (uncle != null && uncle.Color == RedBlackNode.EnumColor.Red)
            {
                parent.SetBlack();
                uncle.SetBlack();
                grandparent.SetRed();
                InsertRB(grandparent.Element);
                return grandparent;
            }
            return null;
        }
        public RedBlackNode InsertTree(object element){
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
                return (RedBlackNode)parent.LeftChild;
            }
            //Se novo valor é maior ou igual o do seu pai
            else
            {
                parent.addRightChild(element);
                return (RedBlackNode)parent.RightChild;
            }

            this.Size++;
        }

    } 
}