using System.Diagnostics;

namespace FileApp
{
    public partial class Form1 : Form
    {
        bool isDraw = false;

        List<Point> points = new List<Point>();

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDraw = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDraw = false;
            panel1.Invalidate();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraw)
            {
                points.Add(new Point(e.X, e.Y));
                //Debug.WriteLine($"{e.X},{e.Y}");
                panel1.Invalidate();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (points != null && points.Count > 1)
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawLines(Pens.Black, points.ToArray());
            }
        }
    }
}