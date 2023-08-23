using System;
using System.Windows.Forms;

namespace EventAppWinformApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += new System.EventHandler(ClickHandler);
        }

        private void ClickHandler(object sender, EventArgs e)
        {
            MessageBox.Show(sender.GetType().ToString());
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
