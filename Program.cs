BST.AVL tree = new(10);
object[] arr = {5, 15, 2, 8, 22};
foreach (var item in arr)
{
tree.Insert(item);
}
tree.show();
// Output:
//           22
//      15
// 10
//           8
//      5
//           2

tree.Insert(25);
tree.show();
// Output:
//                25
//           22
//      15
// 10
//           8
//      5
//           2

tree.Remove(5);
tree.show();
// Output:
//                25
//           22
//      15
// 10
//      8
//           2

tree.Remove(10);
tree.show();
// Output:
//           25
//      22
// 15
//      8
//           2