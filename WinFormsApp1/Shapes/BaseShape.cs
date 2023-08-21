namespace WinFormsApp1.Shapes
{
    public abstract class BaseShape
    {
        public Size Size { get; set; } = new Size(0, 0);

        public Point Location { get; set; } = new Point(0, 0);

        public Pen Pen { get; set; } = Pens.Black;

        public abstract void Draw(Graphics g);
    }
}
