BST.BST tree = new(10);

object[] arr = { 5, 15, 2, 8, 22, 14, 13};

foreach (var item in arr)
{
    tree.Insert(item);
}

tree.show();
tree.show();
tree.Insert(25);
tree.show();
tree.show();
tree.Remove(22);
tree.show();
tree.Remove(5);
tree.show();
tree.Remove(10);
tree.show();
tree.Remove(14);
tree.show();
