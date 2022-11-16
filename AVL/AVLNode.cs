using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST{
    public class AVLNode : Node
    {
        public int BalanceFactor { get; set; }
        public AVLNode(Node parent, object element) : base(parent, element)
        {
            this.BalanceFactor = 0;
        }

        public override string ToString()
        {
            return $"{this.Element}({this.BalanceFactor})";
        }
    }

}