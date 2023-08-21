namespace WinFormsApp1.Shapes
{
    internal class CircleShape : BaseShape
    {
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(this.Pen, this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
        }
    }
}
