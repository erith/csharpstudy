namespace WinFormsApp1.Shapes
{
    internal class TriAngleShape : BaseShape
    {
        public override void Draw(Graphics g)
        {
            var x1 = this.Location.X + (this.Size.Width / 2);
            var y1 = this.Location.Y;

            var x2 = this.Location.X;
            var y2 = this.Location.Y + this.Size.Height;

            var x3 = this.Location.X + this.Size.Width;
            var y3 = this.Location.Y + this.Size.Height;

            g.DrawLine(this.Pen, x1, y1, x2, y2);
            g.DrawLine(this.Pen, x2, y2, x3, y3);
            g.DrawLine(this.Pen, x3, y3, x1, y1);
        }
    }
}
