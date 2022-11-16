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

        public void SetBlack()
        {
            this.Color = EnumColor.Black;
        }

        public void SetRed()
        {
            this.Color = EnumColor.Red;
        }

        public override string ToString()
        {
            return $"{this.Element}({this.Color})";
        }
    }
}