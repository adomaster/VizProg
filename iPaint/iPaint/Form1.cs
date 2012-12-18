using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace iPaint
{
    public partial class Form1 : Form
    {
        List<Shape> shapes = new List<Shape>();
        Boolean flag = false;
        Point LS;
        Pen pmain = new Pen(Color.Black);

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Text=e.X+";"+e.Y;
            if (radioCross.Checked)
            {
                shapes.Add(new Cross(e.X, e.Y));
                ShapesList.Items.Add("Cross" + " " + e.Location);
                flag = false;
            }
            
            if (radioLine.Checked)
            {
                if (!flag)
                {
                    LS = e.Location;
                    flag = true;
                }
                else
                {

                    shapes.Add(new Line(LS,e.Location));
                    ShapesList.Items.Add("Line" + " " + LS + " " + e.Location);
                    flag = false;
                }
            }
            if (radioCircle.Checked)
            {
                if (!flag)
                {
                    LS = e.Location;
                    flag = true;
                }
                else
                {

                    shapes.Add(new Circle(LS, e.Location));
                    ShapesList.Items.Add("Circle" + " " + LS + " " + e.Location);
                    flag = false;
                }
            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape p in this.shapes)
            {
                p.DrawWith(e.Graphics, pmain);

            }

        }

        private void radioCross_CheckedChanged(object sender, EventArgs e)
        {
            flag = false;
        }

        private void radioLine_CheckedChanged(object sender, EventArgs e)
        {
            flag = false;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inFile = "save.txt";
            StreamWriter sw = new StreamWriter(inFile);
            foreach (Shape p in this.shapes)
            {
                p.SaveTo(sw);
            }
            sw.Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string curFile = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(curFile);
                shapes.Clear();
                while (!sr.EndOfStream)
                {
                    string tools = sr.ReadLine();
                    switch (tools)
                    {
                        case "Cross":
                            {
                                shapes.Add(new Cross(sr));                                
                                Refresh();
                                break;
                            }
                        case "Line":
                            {
                                shapes.Add(new Line(sr));                                
                                Refresh();
                                break;
                            }
                    }
                }
                sr.Close();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            flag = true;
            ShapesList.Items.Clear();
            this.Refresh();

        }
    }
}

