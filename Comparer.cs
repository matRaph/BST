using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    internal class Comparer
    {
        public static int comparer(object element1, object element2)
        {
            if (Convert.ToDouble(element1) == Convert.ToDouble(element2)) { return 0; }
            if (Convert.ToDouble(element1) > Convert.ToDouble(element2)) { return 1; }
            else { return -1; }
        }
    }
}
