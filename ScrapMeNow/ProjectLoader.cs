using System;
using System.Windows.Forms;

namespace ScrapMeNow
{
    public partial class ProjectLoader : Form
    {
        public ProjectLoader()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelLoad.Width += 3;
            if (panelLoad.Width >= 700)
            {
                timer1.Stop();
                this.Hide();
                Form1 f = new Form1();
                f.ShowDialog();
            }
        }
    }
}
