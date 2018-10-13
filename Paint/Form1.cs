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
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            panel2.Visible = false;
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
            Stream myStream;
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.RestoreDirectory = true;
            if(savefile.ShowDialog() == DialogResult.OK)
            {
                if((myStream = savefile.OpenFile()) != null)
                {
                    myStream.Close();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            panel2.Visible = true;
            
        }
    }
}
