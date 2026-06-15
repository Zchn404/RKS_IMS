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
    public partial class UpdateUser : MaterialForm
    {
        MainForm mainform;
        private bool isLoading = true;
        private string currentStatus = string.Empty;
        public UpdateUser(MainForm mainform)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.mainform = mainform;
            this.KeyPreview = true;
        }
        public string UserId
        {
            get { return materialLabel5.Text; }
            set { materialLabel5.Text = value; }
        }

        public string Username
        {
            get { return tbUser.Text; }
            set { tbUser.Text = value; }
        }
        public string Phone
        {
            get { return tbPhone.Text; }
            set { tbPhone.Text = value; }
        }
        public string Fullname
        {
            get { return tbFn.Text; }
            set { tbFn.Text = value; }
        }
        public string Role
        {
            get { return cbRole.Text; }
            set { cbRole.Text = value; }
        }
        public string Status
        {
            get { return cbStatus.Text; }
            set { cbStatus.Text = value; }
        }
        
        private void UpdateUser_Load(object sender, EventArgs e)
        {
            tbUser.Focus();
            currentStatus = cbStatus.SelectedItem?.ToString();
            isLoading = false;
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    SqlCommand checkcuser = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @Username AND User_Id <> @User_Id", conn);
                    checkcuser.Parameters.AddWithValue("@Username", tbUser.Text);
                    checkcuser.Parameters.AddWithValue("@User_Id", materialLabel5.Text);
                    int userExists = (int)checkcuser.ExecuteScalar();

                    if (userExists > 0)
                    {
                        MessageBox.Show("User already exists! Please choose a different user name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string updateSql = "UPDATE [User] SET Username = @Username, Phone = @Phone, FullName = @FullName, Role = @Role, Status = @Status WHERE User_Id = @UserId";

                    using (SqlCommand updateComm = new SqlCommand(updateSql, conn))
                    {
                        updateComm.Parameters.AddWithValue("@UserId", materialLabel5.Text);
                        updateComm.Parameters.AddWithValue("@Username", tbUser.Text);
                        updateComm.Parameters.AddWithValue("@Phone", tbPhone.Text);
                        updateComm.Parameters.AddWithValue("@FullName", tbFn.Text);
                        updateComm.Parameters.AddWithValue("@Role", cbRole.Text);
                        updateComm.Parameters.AddWithValue("@Status", cbStatus.Text);
                        updateComm.ExecuteNonQuery();
                    }
                }

                foreach (Form form in Application.OpenForms)
                {
                    if (form is MainForm mainform)
                    {
                        mainform.LoadDataUser();
                    }
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem != null && !isLoading)
            {
                string selectedStatus = cbStatus.SelectedItem.ToString();

                if (selectedStatus == "Resigned" && currentStatus != "Resigned")
                {
                    UpdateResignedDate();
                }

                currentStatus = selectedStatus;
            }
        }
        private void UpdateResignedDate()
        {
            DateTime resignedDate = DateTime.Now;
            string query = "UPDATE [User] SET Resigned = @ResignedDate WHERE User_Id = @UserId";

            try
            {
                using (SqlConnection connection = DatabaseManager.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ResignedDate", resignedDate);
                        command.Parameters.AddWithValue("@UserId", materialLabel5.Text);
                        command.ExecuteNonQuery();
                        
                    }
                }
            }
           catch (Exception ex)
            {
                MessageBox.Show("Error updating resigned date: " + ex.Message);
            }
        }

        private void UpdateUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
