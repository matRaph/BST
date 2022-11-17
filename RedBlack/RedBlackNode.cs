using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST{
    public class RedBlackNode : Node
    {
        public enum EnumColor { Red, Black };
        public EnumColor Color { get; set; }
        public RedBlackNode(Node parent, object element) : base(parent, element)
        {
            this.Color = EnumColor.Red;
        }
        public bool IsBlack()
        {
            return this.Color == EnumColor.Black;
        }

        public void SetBlack()
        {
            this.Color = EnumColor.Black;
        }

        public void SetRed()
        {
            this.Color = EnumColor.Red;
        }

        public override void addLeftChild(object element)
        {
            this.LeftChild = new RedBlackNode(this, element);
        }

        public override void addRightChild(object element)
        {
            this.RightChild = new RedBlackNode(this, element);
        }

        public override string ToString()
        {
            if(this.Color == EnumColor.Red){
                return this.Element.ToString() + "(R)";
            }
            else{
                return this.Element.ToString() + "(B)";
            }
        }
    }
}