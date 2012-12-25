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
    public partial class iPaint : Form
    {
        List<Shape> shapes = new List<Shape>();
        Boolean flag = false;
        Point LS;
        Shape tempShape;
        Pen pmain = new Pen(Color.Black);
        Pen ptemp = new Pen(Color.Gray);
        Pen pcheck = new Pen(Color.Red,2);

        public iPaint()
        {
            InitializeComponent();
        }
        private void addShape(Shape item)
        {
            shapes.Add(item);
            ShapesList.Items.Add(tempShape.Info());
        }
        private void iPaint_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int q = 0;
                foreach (Shape obj in shapes)
                {
                    if (obj.Near(e.Location))
                    {
                        ShapesList.SetSelected(q, true);
                    }
                    q++;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (radioCross.Checked)
                {
                    flag = false;
                    this.Text = Convert.ToString(e.Location);
                    addShape(tempShape); 
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
                        this.Text = Convert.ToString(e.Location) + " " + Convert.ToString(LS);
                        addShape(tempShape);
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
                        this.Text = Convert.ToString(e.Location) + " " + Convert.ToString(LS);
                        addShape(tempShape);
                        flag = false;
                    }
                }
                Refresh();
            }
        }

        private void iPaint_Paint(object sender, PaintEventArgs e)
        {
            if (tempShape != null)
            {
                tempShape.DrawWith(e.Graphics, ptemp);
            }
            foreach (Shape p in this.shapes)
            {
                p.DrawWith(e.Graphics, pmain);
            }
            foreach (int i in ShapesList.SelectedIndices)
            {
                shapes[i].DrawWith(e.Graphics, pcheck);
            }            
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
                        case "Circle":
                            {
                                shapes.Add(new Circle(sr));
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

        private void iPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (radioCross.Checked)
            {
                tempShape = new Cross(e.X, e.Y);
                Refresh();
            }
            else
            {
                if (flag)
                {
                    if (radioLine.Checked)
                    {
                        tempShape = new Line(LS, e.Location);
                    }
                    if (radioCircle.Checked)
                    {
                        tempShape = new Circle(LS, e.Location);
                    }
                    Refresh();
                }
            }
        }

        private void ShapesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = false;
            Refresh();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            while (ShapesList.SelectedIndices.Count > 0)
            {
                shapes.RemoveAt(ShapesList.SelectedIndices[0]);
                ShapesList.Items.RemoveAt(ShapesList.SelectedIndices[0]);
            }
            Refresh();

        }

        private void radioCross_CheckedChanged(object sender, EventArgs e)
        {
            flag = false;
        }

        private void radioLine_CheckedChanged(object sender, EventArgs e)
        {
            flag = false;
        }

        private void radioCircle_CheckedChanged(object sender, EventArgs e)
        {
            flag = false;
        }
    }
}

