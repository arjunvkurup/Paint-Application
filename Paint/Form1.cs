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
using System.Drawing.Imaging;

namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        Bitmap bmp;
        Rectangle rec;
        bool rect = false;
        bool sq = false;
        bool circ = false;
        int ab, ac;
        int trig = 0;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 1);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Font myfont = new Font("Helvetica", 40, FontStyle.Regular);
            Brush mybrush = new SolidBrush(Color.Black);
            bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);
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
            dialogue.Title = "New Image";
            dialogue.DefaultExt = "jpeg";
            dialogue.Filter = "JPEG files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
            dialogue.FilterIndex = 2;
            if (dialogue.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(dialogue.FileName, ImageFormat.Jpeg);

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
            rect = true;
            trig = 1;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ab = Location.X;
            ac = Location.Y;
            Rectangle rec = new Rectangle(ab, ac, 250, 250);
            circ = true;
            trig = 2;
            g.DrawEllipse(pen, rec);
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rec = new Rectangle(20, 20, 250, 250);
            sq = true;
            trig = 3;
            g.DrawRectangle(pen, rec);
        }

        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void backgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.ShowDialog();
            panel1.BackColor = c.Color;
        }

        private void shapeColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.ShowDialog();
            if (rect && trig == 1)
            {
                SolidBrush sb = new SolidBrush(c.Color);
                g.FillRectangle(sb, 20, 20, 250, 200);
            }
            else if(sq && trig == 3)
            {
                SolidBrush sb = new SolidBrush(c.Color);
                g.FillRectangle(sb, 20, 20, 250, 250);
            }
            else if(circ && trig == 2)
            {
                SolidBrush sb = new SolidBrush(c.Color);
                g.FillEllipse(sb, ab, ac, 250, 200);
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.ShowDialog();

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(panel1.BackColor);
            panel1.BackColor = Color.White;
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            {
                openFileDialog1.Title = "Browse Image Files";
                openFileDialog1.DefaultExt = "jpeg";
                openFileDialog1.Filter = "jpeg files (*.jpeg)|*.jpeg";
                openFileDialog1.FilterIndex = 2;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                bmp = new Bitmap(sFileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
