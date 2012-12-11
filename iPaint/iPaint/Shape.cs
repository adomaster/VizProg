using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

namespace iPaint
{
    abstract class Shape
    {
        public abstract void DrawWith(Graphics g, Pen p);
        public abstract void SaveTo(StreamWriter file);
        public abstract void LoadTo(StreamReader file);
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
        public Cross(StreamReader sr)
        {
            string line = sr.ReadLine();
            string[] foo = line.Split(' ');
            X = Convert.ToInt32(foo[0]);
            Y = Convert.ToInt32(foo[1]);

        }

        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, X - 5, Y - 5, X + 5, Y + 5);
            g.DrawLine(p, X + 5, Y - 5, X - 5, Y + 5);
        }
        public override void SaveTo(StreamWriter file)
        {
            file.WriteLine("Cross");
            file.WriteLine(Convert.ToString(X) + " " + Convert.ToString(Y));
        }
        public override void LoadTo(StreamReader file)
        {

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
        public Line(StreamReader sr)
        {
            string line1;
            string line2;
            line1 = sr.ReadLine();
            line2 = sr.ReadLine();
            string[] foo1 = line1.Split(' ');
            string[] foo2 = line2.Split(' ');
            S.X = Convert.ToInt32(foo1[0]);
            E.X = Convert.ToInt32(foo2[0]);
            S.Y = Convert.ToInt32(foo1[1]);
            E.Y = Convert.ToInt32(foo2[1]);
        }
        public override void DrawWith(Graphics g, Pen p)
        {

            g.DrawLine(p, S.X, S.Y, E.X, E.Y);
        }
        public override void SaveTo(StreamWriter file)
        {
            file.WriteLine("Line");
            file.WriteLine(Convert.ToString(S.X) + " " + Convert.ToString(S.Y));
            file.WriteLine(Convert.ToString(E.X) + " " + Convert.ToString(E.Y));
        }
        public override void LoadTo(StreamReader file)
        {
        }


    }



}
