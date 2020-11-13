using System;

namespace ScrapMeNow
{
    public partial class Help : MaterialSkin.Controls.MaterialForm
    {
        public Help()
        {
            InitializeComponent();
            var skinmanager = MaterialSkin.MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            skinmanager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey800,
                MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Grey800,
                MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e) { }

        private void materialFlatButton2_Click(object sender, EventArgs e) { }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }
    }
}
