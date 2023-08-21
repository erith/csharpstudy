namespace WinFormsApp1.Shapes
{
    internal class SquareShape : BaseShape
    {
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(this.Pen, new Rectangle() { Size = this.Size, Location = this.Location });
        }
    }
}
