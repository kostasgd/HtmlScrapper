using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace ScrapMeNow
{
    public partial class Contact : MaterialSkin.Controls.MaterialForm
    {
        public Contact()
        {
            InitializeComponent();
            var skinmanager = MaterialSkin.MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            skinmanager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey800,
                MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Grey800,
                MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string filename = "";
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = " Images(.jpg,.png)|*.png;*.jpg;|Pdf files|*.pdf";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    filename = of.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidEmail(txtSender.Text.Trim()) & checktxt())
                {
                    SmtpClient client = new SmtpClient();
                    client.Port = Convert.ToInt32(txtPortNum.Text.Trim());
                    client.Host = txtSmtpServer.Text.Trim();
                    client.EnableSsl = cbSSL.Checked;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(Convert.ToString(txtSender.Text.Trim()), Convert.ToString(txtSenderPasswd.Text.Trim()));

                    //message details
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(Convert.ToString(txtSender.Text.Trim()));
                    mail.To.Add(Convert.ToString(txtRecipient.Text.Trim()));
                    mail.Subject = Convert.ToString(txtSubject.Text);
                    mail.Body = txtBody.Text + " Sended by : " + txtEmail.Text;
                    if (filename.Length > 0)
                    {
                        Attachment att = new Attachment(filename);
                        mail.Attachments.Add(att);
                    }
                    if (IsTextsNotEmpty())
                    {
                        client.Send(mail);
                        MessageBox.Show("You're mail has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please fill all textboxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    filename = "";
                }
                else
                {
                    MessageBox.Show("Something is not valid ,please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        bool IsTextsNotEmpty()
        {
            if (txtSender.Text != null & txtSenderPasswd.Text != null & txtSmtpServer.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                email = txtEmail.Text.Trim();
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool checktxt()
        {
            if (txtEmail.Text == string.Empty)
            {
                return false;
            }
            return true;
        }
        private void txtSender_Validated(object sender, EventArgs e)
        {
            if (txtSender.Text.EndsWith("gmail.com"))
            {
                txtSmtpServer.Text = "smtp.gmail.com";
                txtPortNum.Text = "587";
            }
            else if (txtSender.Text.EndsWith("yahoo.com"))
            {
                txtSmtpServer.Text = "smtp.yahoo.com";
                txtPortNum.Text = "465";
            }
            else if (txtSender.Text.EndsWith("outlook.com") | txtSender.Text.EndsWith("windowslive.com"))
            {
                txtSmtpServer.Text = "smtp.outlook.com";
                txtPortNum.Text = "587";
            }
        }
    }
}
