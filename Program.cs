BST.RedBlack tree = new(41);
object[] arr = {38, 31, 12, 19, 8};
foreach (var item in arr){
    tree.InsertRB(item);
    tree.show();
}

//Saídas

//Adicionando 41
// 41 (B)

//Adicionando 38
// 41(B)
    //38(R)

//Adicionando 31 e rotacionando
//      41(R)
// 38(B)
//      31(R)

//Adicionando 12 e recolorando
//      41(B)
// 38(B)
//      31(B)
//           12(R)

//Adicionando 19 e rotacionando
//      41(B)
// 38(B)
//           31(R)
//      19(B)
//           12(R)

//Adicionando 8 e recolorindo
//      41(B)
// 38(B)
//           31(B)
//      19(R)
//           12(B)
//                8(R)