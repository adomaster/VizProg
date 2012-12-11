using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPaint
{
    public partial class Form1 : Form
    {
        List<Shape> shapes = new List<Shape>();
        Pen pmain = new Pen(Color.Black);

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Text=e.X+";"+e.Y;
            shapes.Add(new Cross(e.X,e.Y));
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape p in this.shapes)
            {
                p.DrawWith(e.Graphics, pmain);

            }

        }
    }
}

