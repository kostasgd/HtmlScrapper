using System;

namespace ScrapMeNow
{
    public partial class About : MaterialSkin.Controls.MaterialForm
    {
        public About()
        {
            InitializeComponent();
            var skinmanager = MaterialSkin.MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            skinmanager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey800,
                MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Grey800,
                MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
