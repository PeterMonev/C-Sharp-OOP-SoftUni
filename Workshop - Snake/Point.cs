using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop___Snake
{
    public class Point
    {
        public Point(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public int Left { get; set; }
        public int Top { get; set; }

        public override string ToString()
        {
            return $"({Left}, {Top})";
        }
    }

}
