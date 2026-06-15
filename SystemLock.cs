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

namespace RKS_Inventory
{
    public partial class SystemLock : MaterialForm
    {
        Staff staff;
        public SystemLock(Staff staff)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.staff = staff;
        }
        public string User
        {
            get { return lblStaff.Text; }
            set { lblStaff.Text = value; }
        }
        public string Role
        {
            get { return lblRole.Text; }
            set { lblRole.Text = value; }
        }
        public string UserSA
        {
            get { return lblUserSA.Text; }
            set { lblUserSA.Text = value; }
        }

        private void SystemLock_Load(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbPass.Text))
                {
                    MessageBox.Show("Please Input Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "SELECT Password FROM [User] WHERE Username = @Username";

                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@Username", lblStaff.Text);

                        using (SqlDataReader dr = comm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string storedEncryptedPassword = dr["Password"].ToString();
                                string userInputPassword = tbPass.Text;

                                string decryptedPassword = EncryptionHelper.Decrypt(storedEncryptedPassword);

                                if (userInputPassword == decryptedPassword)
                                {
                                    this.Hide();
                                    Staff staff = new Staff();
                                    staff.labelUser = "Welcome: " + lblStaff.Text + " -";
                                    staff.labelRole = lblRole.Text;
                                    staff.UserSA = lblUserSA.Text;
                                    staff.ShowDialog();
                                }

                                else
                                {
                                    MessageBox.Show("Incorrect Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbPass.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbPass.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnEnter.PerformClick();
            }
        }
    }
}
