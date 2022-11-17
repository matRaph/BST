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
            root.SetBlack();
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

            // //Caso 2: Se o tio é vermelho, troca a cor do pai e do tio para preto e a cor do avô para vermelho,
            // //e chama a função recursivamente para o avô
            // this.Case2(insertedNode);
            
            // //Caso 3: Se o tio é preto, faz rotações para balancear a árvore
            // this.Case3(insertedNode);

            VerifyInsert(insertedNode);
            
        }
        public RedBlackNode VerifyInsert(RedBlackNode insertedNode){
            //Armazena os nós que serão verificados
            RedBlackNode? parent = (RedBlackNode)insertedNode.Parent;
            RedBlackNode? grandparent = (RedBlackNode)parent.Parent;
            RedBlackNode? uncle = grandparent != null 
                ? (RedBlackNode)grandparent.LeftChild == parent ? 
                    (RedBlackNode)grandparent.RightChild : (RedBlackNode)grandparent.LeftChild
                        : null;

            //Caso 1: Se o pai é preto
            if (parent.IsBlack())
            {
                return insertedNode;
            }

            //Caso 2: Se o tio é vermelho, troca a cor do pai e do tio para preto e a cor do avô para vermelho,
            //e chama a função recursivamente para o avõ
            if(uncle != null && !uncle.IsBlack()){
                parent.SetBlack();
                uncle.SetBlack();
                if(grandparent != Root){
                    grandparent.SetRed();
                    VerifyInsert(grandparent);
                }
                return insertedNode;
                // grandparent.SetRed();
                // return VerifyInsert(grandparent);
            }

            //Caso 3: Se o tio é preto, faz as rotações para balancear a árvore
            if(uncle == null || uncle.IsBlack()){
                //Caso 3.1: Se o nó inserido é filho esquerdo do pai e o pai é filho esquerdo do avõ,
                //faz uma rotação simples à direita
                if(insertedNode == parent.LeftChild && parent == grandparent.LeftChild){
                    RotateRight(grandparent);
                    parent.SetBlack();
                    grandparent.SetRed();
                    return insertedNode;
                }
                
                //Caso 3.2: Se o nó inserido é filho direito do pai e o pai é filho direito do avõ,
                //faz uma rotação simples à esquerda
                if(insertedNode == parent.RightChild && parent == grandparent.RightChild){
                    RotateLeft(grandparent);
                    parent.SetBlack();
                    grandparent.SetRed();
                    return insertedNode;
                }

                //Caso 3.3: Se o nó inserido é filho esquerdo do pai, e o pai é filho direito do avõ,
                //faz uma rotação dupla à esquerda
                if(insertedNode == parent.LeftChild && parent == grandparent.RightChild){
                    RotateRight(parent);
                    RotateLeft(grandparent);
                    insertedNode.SetBlack();
                    grandparent.SetRed();
                    return insertedNode;
                }

                //Caso 3.4: Se o nó inserido é filho direito do pai, e o pai é filho esquerdo do avõ,
                //faz uma rotação dupla à direita
                if(insertedNode == parent.RightChild && parent == grandparent.LeftChild){
                    RotateLeft(parent);
                    RotateRight(grandparent);
                    insertedNode.SetBlack();
                    grandparent.SetRed();
                    return insertedNode;
                }
            }
            return insertedNode;
        }
        
        public void RotateRight(RedBlackNode node){
            RedBlackNode parent = (RedBlackNode)node.Parent;
            RedBlackNode leftChild = (RedBlackNode)node.LeftChild;
            RedBlackNode leftChildRightChild = (RedBlackNode)leftChild.RightChild;

            //Faz a rotação
            leftChild.RightChild = node;
            node.LeftChild = leftChildRightChild;
            leftChild.Parent = parent;
            node.Parent = leftChild;

            //Verifica se o nó que foi rotacionado é a raiz
            if (parent == null)
            {
                this.Root = leftChild;
            }
            else
            {
                if (parent.LeftChild == node)
                {
                    parent.LeftChild = leftChild;
                }
                else
                {
                    parent.RightChild = leftChild;
                }
            }
        }
        public void RotateLeft(RedBlackNode node){
            RedBlackNode parent = (RedBlackNode)node.Parent;
            RedBlackNode rightChild = (RedBlackNode)node.RightChild;
            RedBlackNode rightChildLeftChild = (RedBlackNode)rightChild.LeftChild;

            //Faz a rotação
            rightChild.LeftChild = node;
            node.RightChild = rightChildLeftChild;
            rightChild.Parent = parent;
            node.Parent = rightChild;

            //Verifica se o nó que foi rotacionado é a raiz
            if (parent == null)
            {
                this.Root = rightChild;
            }
            else
            {
                if (parent.LeftChild == node)
                {
                    parent.LeftChild = rightChild;
                }
                else
                {
                    parent.RightChild = rightChild;
                }
            }
        }
        public RedBlackNode InsertTree(object element){
            //O pai do novo nó
            RedBlackNode parent = null;
            RedBlackNode auxNode = (RedBlackNode)this.Root;

            while (auxNode != null)
            {
                parent = auxNode;
                //Se elemento novo for menor que nó atual
                if (Comparer.comparer(element, auxNode.Element) == -1)
                {
                    auxNode = (RedBlackNode)auxNode.LeftChild;
                }
                //Se elemento novo for maior ou igual ao nó atual
                else
                {
                    auxNode = (RedBlackNode)auxNode.RightChild;
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