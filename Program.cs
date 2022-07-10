BST.BST tree = new(1);
tree.Root.addLeftChild(2);
tree.Root.leftChild().addLeftChild(4);

Console.WriteLine(tree.height());