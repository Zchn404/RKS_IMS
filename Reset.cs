using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Org.BouncyCastle.Asn1.Cmp;

namespace RKS_Inventory
{
    public partial class Reset : MaterialForm
    {
        MainForm username;
        public Reset()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
        }
        public string labelReset
        {
            get { return lbluser.Text; }
            set { lbluser.Text = value; }
        }
        public string labelEmail
        {
            get { return tbuseremail.Text; }
            set { tbuseremail.Text = value; }
        }


        private void Reset_Load(object sender, EventArgs e)
        {
            GenerateAndSendOtp();
            tbNew.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {

                if (tbNew.Text == string.Empty || tbNewP.Text == string.Empty)
                {
                    MessageBox.Show("Please Fill Out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbNew.Text != tbNewP.Text)
                {
                    MessageBox.Show("The password you typed does not match.", "RESET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Reset password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        using (SqlConnection conn = DatabaseManager.GetConnection())
                        {
                            conn.Open();
                            string query = "UPDATE [User] SET Password = @NewPassword WHERE Username = @Username";
                            string encryptedPassword = EncryptionHelper.Encrypt(tbNew.Text);

                            using (SqlCommand comm = new SqlCommand(query, conn))
                            {
                                comm.Parameters.AddWithValue("@NewPassword", encryptedPassword);
                                comm.Parameters.AddWithValue("@Username", lbluser.Text);

                                int rowsAffected = comm.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Password has been successfully reset", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tbNew.Clear();
                                    tbNewP.Clear();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("No user found with the specified username.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void tbNewP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnReset.PerformClick();
            }
        }

        private void lbluser_Click(object sender, EventArgs e)
        {

        }
        private string generatedOtp;
        private static Random random = new Random();
        private void tbvcsubmit_Click(object sender, EventArgs e)
        {
            if (tbverifcode.Text == generatedOtp)
            {
                MessageBox.Show("Verification Successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbuseremail.Visible = false;
                tbverifcode.Visible = false;
                btnvcsubmit.Visible = false;
                materialLabel4.Visible = false;
                materialLabel3.Visible = false;
                materialLabel1.Visible = true;
                materialLabel2.Visible = true;
                tbNew.Visible = true;
                tbNewP.Visible = true;
                btnReset.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid Verification Code. Please try again!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        string emailTo;
        private void GenerateAndSendOtp()
        {
            generatedOtp = GenerateOtp();
            emailTo = tbuseremail.Text;

            bool isSent = SendOtpEmail(generatedOtp);

            if (isSent)
            {
                materialLabel4.Text = "We've sent a verification code to your email.";
            }
            else
            {
                materialLabel4.Text = "Failed to send OTP. Check Connection!";
            }
        }

        private string GenerateOtp()
        {
            return random.Next(100000, 999999).ToString();
        }

        private bool SendOtpEmail(string otpCode)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Credentials = new NetworkCredential("johnpaul.pausanosact2022@gmail.com", "txgx dpga flht blhl");
                    client.EnableSsl = true;

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("johnpaul.pausanosact2022@gmail.com");
                        mailMessage.Subject = "OTP Verification Code";
                        mailMessage.IsBodyHtml = true;
                        mailMessage.To.Add(emailTo);

                        mailMessage.Body = $@"
                <html>
                <body>
                    <h2 style='font-size:24px; color:blue;'>Your OTP Code</h2>
                    <p style='font-size:18px;'>Please use the following OTP to reset your account:</p>
                    <p style='font-size:24px; font-weight:bold; color:red;'>{otpCode}</p>
                    <br>
                    <p style='font-size:16px;'>Thank you for using our service!</p>
                </body>
                </html>";
                        client.Send(mailMessage);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
    }
}
