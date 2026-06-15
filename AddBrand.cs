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
using System.Xml.Linq;

namespace RKS_Inventory
{
    public partial class AddBrand : MaterialForm
    {
        MainForm mainform;
        public AddBrand(MainForm mainform)
        {
            InitializeComponent();
            this.mainform = mainform;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            LoadCategory();
            mainform.LoadDataCategory();
            this.KeyPreview = true;
        }
        public string BrandId
        {
            get { return materialLabel2.Text; }
            set { materialLabel2.Text = value; }
        }

        public string Brand
        {
            get { return materialTextBox1.Text; }
            set { materialTextBox1.Text = value; }
        }
        public string Category
        {
            get { return cbCategory.Text; }
            set { cbCategory.Text = value; }
        }
        public bool IsCategoryEnabled
        {
            set
            {
                materialButton1.Visible = false;
                cbCategory.Enabled = false;
            }
        }
        public bool BrandAdd
        {
            set
            {              
                materialButton3.Visible = false;
            }
        }
        private void AddBrand_Load(object sender, EventArgs e)
        {
            materialTextBox1.Focus();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialTextBox1.Text == string.Empty)
            {
                MessageBox.Show("Please Input Brand Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                SqlCommand checkbrand = new SqlCommand("SELECT COUNT(*) FROM Brand WHERE Brand = @Brand", conn);
                checkbrand.Parameters.AddWithValue("@Brand", materialTextBox1.Text);
                int brandExists = (int)checkbrand.ExecuteScalar();

                if (brandExists > 0)
                {
                    MessageBox.Show("Brand already exists! Please choose a different brand name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand comm = new SqlCommand("INSERT INTO Brand VALUES (@Brand, @Category_Id)", conn);
                comm.Parameters.AddWithValue("@Brand", materialTextBox1.Text);
                comm.Parameters.AddWithValue("@Category_Id", cbCategory.SelectedValue);
                comm.ExecuteNonQuery();
                conn.Close();
                this.Hide();
                mainform.LoadDataBrand();
            }
        }

        public void LoadCategory()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                string query = "SELECT * FROM Category";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cbCategory.DataSource = dt;
                    cbCategory.DisplayMember = "Category";
                    cbCategory.ValueMember = "Category_Id";
                }
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    SqlCommand checkbrand = new SqlCommand("SELECT COUNT(*) FROM Brand WHERE Brand = @Brand AND Brand_Id <> @Brand_Id", conn);
                    checkbrand.Parameters.AddWithValue("@Brand", materialTextBox1.Text);
                    checkbrand.Parameters.AddWithValue("@Brand_Id", materialLabel2.Text);
                    int brandExists = (int)checkbrand.ExecuteScalar();

                    if (brandExists > 0)
                    {
                        MessageBox.Show("Brand already exists! Please choose a different brand name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string updateSql = "UPDATE Brand SET Brand = @Brand WHERE Brand_Id = @BrandId";

                    using (SqlCommand updateComm = new SqlCommand(updateSql, conn))
                    {
                        updateComm.Parameters.AddWithValue("@BrandId", materialLabel2.Text);
                        updateComm.Parameters.AddWithValue("@Brand", materialTextBox1.Text);
                        updateComm.ExecuteNonQuery();
                    }
                }

                foreach (Form form in Application.OpenForms)
                {
                    if (form is MainForm mainform)
                    {
                        mainform.LoadDataBrand();
                        mainform.LoadData();
                    }
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AddBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
