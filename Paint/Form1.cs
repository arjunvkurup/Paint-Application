using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 1);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Font myfont = new Font("Helvetica", 40, FontStyle.Regular);
            Brush mybrush = new SolidBrush(Color.Black);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.Cursor = Cursors.Cross;
            if (moving && x != -1 && y !=- 1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //  Opens the colour box
        private void coloursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colourbox = new ColorDialog();
            colourbox.ShowDialog(); 
            pen.Color = colourbox.Color;
        }

        //  Saving the file
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogue = new SaveFileDialog();
            if(dialogue.ShowDialog() == DialogResult.OK)
            {
               // int width = Convert.ToInt32(drawImage.width);

            }
        }

        private void pxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 1);
            pen = pen1;
        }

        private void pxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 2);
            pen = pen1;
        }

        private void pxToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 3);
            pen = pen1;
        }

        private void pxToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 5);
            pen = pen1;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle rec = new Rectangle(20, 20, 250, 200);
            g.DrawRectangle(pen, rec);
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            int enx, eny;
            x = Location.X;
            y = Location.Y;
            Rectangle rec = new Rectangle(x, y, 250, 250);
            g.DrawEllipse(pen, rec);
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle rec = new Rectangle(20, 20, 250, 250);
            g.DrawRectangle(pen, rec);
        }

        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void backgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if(c.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = c.Color;
                backgroundColourToolStripMenuItem.BackColor = c.Color;
            }
        }

        private void shapeColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                //e.Graphics.Fill
            }
        }
    }
}
