using System.Text.Json;

namespace FileApp
{
    public partial class Form1 : Form
    {
        bool isDraw = false;

        Color currentLineColor = Color.Black;

        /// <summary>
        /// 선의 종류
        /// </summary>
        List<OzLine> points = new List<OzLine>();

        /// <summary>
        /// 생성자
        /// </summary>
        public Form1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 패널에 마우스를 누를 때 처리되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            points.Add(new OzLine() { Color = currentLineColor, Points = new List<Point>() });
            isDraw = true;
        }

        /// <summary>
        /// 패널에 마우스를 뗄 때 처리되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDraw = false;

            panel1.Invalidate();
        }

        /// <summary>
        /// 패널에 마우스를 움직일때 이벤트 핸들러
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
        /// 클리어 버튼 클릭 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            panel1.Invalidate();
        }

        /// <summary>
        /// Panel을 새로그릴때 처리되는 paint 이벤트 핸들러
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
        /// 색상 변경 이벤트 핸들러
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
        /// 세이브 메뉴 클릭 이벤트 핸들러
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

                    MessageBox.Show("저장하였습니다.");
                }
            }
        }

        /// <summary>
        /// 그림 불러오기 메뉴 클릭 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("저장되지 않은 그림은 사라집니다. 그림을 불러오시겠습니까?", "질문", MessageBoxButtons.YesNo) == DialogResult.No)
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