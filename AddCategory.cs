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
    public partial class AddCategory : MaterialForm
    {
        MainForm mainform;
        public AddCategory(MainForm mainform)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.mainform = mainform;
            this.KeyPreview = true;
        }
        public string CategoryId
        {
            get { return materialLabel2.Text; }
            set { materialLabel2.Text = value; }
        }

        public string Category
        {
            get { return materialTextBox1.Text; }
            set { materialTextBox1.Text = value; }
        }
        public bool IsCategoryEnabled
        {
            set
            {
                materialButton1.Visible = false;
            }
        }
        public bool CategoryAdd
        {
            set
            {
                materialButton3.Visible = false;
            }
        }
        private void AddCategory_Load(object sender, EventArgs e)
        {
            materialTextBox1.Focus();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialTextBox1.Text == string.Empty)
            {
                MessageBox.Show("Please Input Category Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                SqlCommand checkcategory = new SqlCommand("SELECT COUNT(*) FROM Category WHERE Category = @Category", conn);
                checkcategory.Parameters.AddWithValue("@Category", materialTextBox1.Text);
                int brandExists = (int)checkcategory.ExecuteScalar();

                if (brandExists > 0)
                {
                    MessageBox.Show("Category already exists! Please choose a different category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand comm = new SqlCommand("INSERT INTO Category VALUES (@Category)", conn);
                comm.Parameters.AddWithValue("@Category", materialTextBox1.Text);
                comm.ExecuteNonQuery();
                conn.Close();
                this.Hide();
                mainform.LoadDataCategory();
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    SqlCommand checkcategory = new SqlCommand("SELECT COUNT(*) FROM Category WHERE Category = @Category AND Category_Id <> @Category_Id", conn);
                    checkcategory.Parameters.AddWithValue("@Category", materialTextBox1.Text);
                    checkcategory.Parameters.AddWithValue("@Category_Id", materialLabel2.Text);
                    int brandExists = (int)checkcategory.ExecuteScalar();

                    if (brandExists > 0)
                    {
                        MessageBox.Show("Category already exists! Please choose a different category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string updateSql = "UPDATE Category SET Category = @Category WHERE Category_Id = @CategoryId";

                    using (SqlCommand updateComm = new SqlCommand(updateSql, conn))
                    {
                        updateComm.Parameters.AddWithValue("@CategoryId", materialLabel2.Text);
                        updateComm.Parameters.AddWithValue("@Category", materialTextBox1.Text);
                        updateComm.ExecuteNonQuery();
                    }
                }

                foreach (Form form in Application.OpenForms)
                {
                    if (form is MainForm mainform)
                    {
                        mainform.LoadDataCategory();
                    }
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
