using WinFormsApp1.Shapes;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        List<BaseShape> _baseShapes = new List<BaseShape>();

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Paint += PictureBox1_Paint;
        }

        private void PictureBox1_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            foreach (var shape in _baseShapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            var x = rnd.Next(0, pictureBox1.Width);
            var y = rnd.Next(0, pictureBox1.Height);
            var w = rnd.Next(10, 50);
            var h = rnd.Next(10, 50);

            _baseShapes.Add(new CircleShape()
            {
                Size = new Size() { Width = w, Height = h },
                Location = new Point(x, y)
            });

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Add Triangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            var x = rnd.Next(0, pictureBox1.Width);
            var y = rnd.Next(0, pictureBox1.Height);
            var w = rnd.Next(10, 50);
            var h = rnd.Next(10, 50);

            _baseShapes.Add(new TriAngleShape()
            {
                Size = new Size() { Width = w, Height = h },
                Location = new Point(x, y)
            });

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Square Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            var x = rnd.Next(0, pictureBox1.Width);
            var y = rnd.Next(0, pictureBox1.Height);
            var w = rnd.Next(10, 50);
            var h = rnd.Next(10, 50);

            _baseShapes.Add(new SquareShape()
            {
                Size = new Size() { Width = w, Height = h },
                Location = new Point(x, y)
            });

            pictureBox1.Invalidate();
        }
    }
}