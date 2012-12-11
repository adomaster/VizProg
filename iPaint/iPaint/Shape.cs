using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace iPaint
{
    abstract class Shape
    {
        public abstract void DrawWith(Graphics g, Pen p);
    }
    class Cross : Shape
    {
        private int X, Y;


        public Cross(int _X, int _Y)
        {
            this.X = _X; this.Y = _Y;
        }
        public Cross()
        {
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, X - 5, Y - 5, X + 5, Y + 5);
            g.DrawLine(p, X + 5, Y - 5, X - 5, Y + 5);
        }

    }
    class Line : Shape
    {
        private Point S, E;
        public Line(Point _S, Point _E)
        {
            this.S = _S;
            this.E = _E;
        }
        public Line()
        {
        }
        public override void DrawWith(Graphics g, Pen p)
        {

            g.DrawLine(p, S.X, S.Y, E.X, E.Y);
        }

    }



}
