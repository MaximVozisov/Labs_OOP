using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12
{
    internal class Point
    {
        public int data;
        public Point next, //адрес следующего элемента
                     pred;//адрес предыдущего элемента
        public Point()
        {
            data = 0;
            next = null;
            pred = null;
        }
        public Point(int d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }
}
