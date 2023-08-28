using System.Text.Json;

namespace FileApp
{
    public partial class Form1 : Form
    {
        bool isDraw = false;

        Color currentLineColor = Color.Black;

        /// <summary>
        /// ���� ����
        /// </summary>
        List<OzLine> points = new List<OzLine>();

        /// <summary>
        /// ������
        /// </summary>
        public Form1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// �гο� ���콺�� ���� �� ó���Ǵ� �̺�Ʈ �ڵ鷯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            points.Add(new OzLine() { Color = currentLineColor, Points = new List<Point>() });
            isDraw = true;
        }

        /// <summary>
        /// �гο� ���콺�� �� �� ó���Ǵ� �̺�Ʈ �ڵ鷯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDraw = false;

            panel1.Invalidate();
        }

        /// <summary>
        /// �гο� ���콺�� �����϶� �̺�Ʈ �ڵ鷯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraw)
            {
                var idx = points.Count - 1;
                points[idx].Points.Add(new Point(e.X, e.Y));
                panel1.Invalidate();
            }
        }

        /// <summary>
        /// Ŭ���� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            panel1.Invalidate();
        }

        /// <summary>
        /// Panel�� ���α׸��� ó���Ǵ� paint �̺�Ʈ �ڵ鷯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (points != null && points.Any())
            {
                foreach (var pts in points)
                {
                    if (pts != null && pts.Points.Count > 1)
                    {
                        e.Graphics.DrawLines(new Pen(pts.Color, 2.0f), pts.Points.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// ���� ���� �̺�Ʈ �ڵ鷯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorButton_Click(object sender, EventArgs e)
        {
            using ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                currentLineColor = dlg.Color;
                colorButton.BackColor = dlg.Color;
            }
        }

        /// <summary>
        /// ���̺� �޴� Ŭ�� �̺�Ʈ �ڵ鷯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Oz Draw Files | *.ozd";
                dlg.DefaultExt = "ozd";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var data = System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(points));

                    System.IO.File.WriteAllBytes(dlg.FileName, data);

                    MessageBox.Show("�����Ͽ����ϴ�.");
                }
            }
        }

        /// <summary>
        /// �׸� �ҷ����� �޴� Ŭ�� �̺�Ʈ �ڵ鷯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("������� ���� �׸��� ������ϴ�. �׸��� �ҷ����ðڽ��ϱ�?", "����", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Oz Draw Files | *.ozd";
                dlg.DefaultExt = "ozd";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var data = File.ReadAllBytes(dlg.FileName);
                    points = JsonSerializer.Deserialize<List<OzLine>>(System.Text.Encoding.UTF8.GetString(data));
                    panel1.Invalidate();

                }
            }
        }


        private async void animationButton_Click(object sender, EventArgs e)
        {
            var targetPoints = new List<OzLine>(points);
            points.Clear();
            foreach (var tp in targetPoints)
            {
                var lines = new OzLine() { Color = tp.Color, Points = new List<Point>() };
                points.Add(lines);
                foreach (var pt in tp.Points)
                {
                    await Task.Delay(100);
                    lines.Points.Add(pt);
                    panel1.Invalidate();
                }
            }
        }
    }


}