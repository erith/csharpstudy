namespace WinFormsApp1.Shapes
{
    internal class StarShape : BaseShape
    {
        #region 별 그리는 포인드
        private PointF[] StarPoints(int num_points, Rectangle bounds)
        {
            // Make room for the points.
            PointF[] pts = new PointF[num_points];

            double rx = bounds.Width / 2;
            double ry = bounds.Height / 2;
            double cx = bounds.X + rx;
            double cy = bounds.Y + ry;

            // Start at the top.
            double theta = -Math.PI / 2;
            double dtheta = 4 * Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                pts[i] = new PointF(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
            }

            return pts;
        }
        #endregion

        public override void Draw(Graphics g)
        {
            var points = this.StarPoints(5, new Rectangle() { Location = this.Location, Size = this.Size });
            g.DrawPolygon(this.Pen, points);
        }
    }
}
