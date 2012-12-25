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
        public abstract bool Near(Point A);
        public abstract string Info();
        public float Dist(Point A, Point B)
        {
            return ((float)Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2)));
        }
    }
    class Cross : Shape
    {
        private int X, Y;
        private Point P;

        public Cross(int _X, int _Y)
        {
            this.X = _X; this.Y = _Y;
            P.X = X;
            P.Y = Y;
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
        public override bool Near(Point A)
        {
            return (Dist(A,P) <= 3);
        }
        public override string Info()
        {
            return "Cross" + " " + P;
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
        public override bool Near(Point A)
        {
            return (((Dist(S, A) + Dist(E, A)) - Dist(S, E)) <= 1);
        }
        public override string Info()
        {
            return "Line" + " " + S + " " + E;
        }
    }
    class Circle : Shape
    {
        private Point S, E;        

        public Circle(Point _S, Point _E)
        {
            this.S = _S;
            this.E = _E;
        }
        private int rad
        {
            get
            {
                return Convert.ToInt32(Math.Sqrt((E.X - S.X) * (E.X - S.X) + (E.Y - S.Y) * (E.Y - S.Y)));
            }
        }
        public Circle(StreamReader sr)
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
            g.DrawEllipse(p, S.X - rad, S.Y - rad, rad * 2, rad * 2);
        }
        public override void SaveTo(StreamWriter file)
        {
            file.WriteLine("Circle");
            file.WriteLine(Convert.ToString(S.X) + " " + Convert.ToString(S.Y));
            file.WriteLine(Convert.ToString(E.X) + " " + Convert.ToString(E.Y));
        }
        public override bool Near(Point A)
        {
            return ((Math.Abs(Dist(S, A) - Dist(S, E)) <= 3));
        }
        public override string Info()
        {
            return "Circle " + "center: " + S + " radius: " + rad;
        }
    }
}
