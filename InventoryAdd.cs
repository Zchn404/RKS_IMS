using MaterialSkin;
using MaterialSkin.Controls;
using MySqlX.XDevAPI;
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
    public partial class InventoryAdd : MaterialForm
    {
        internal static object getform2;

        public InventoryAdd()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.KeyPreview = true;
        }
        //private void MultiplyAndDisplayResult()
        //{
        //    //if (double.TryParse(txtQuantity.Text, out double num1) && double.TryParse(txtPrice.Text, out double num2))
        //    //{
        //    //    txtTotalIncome.Text = (num1 * num2).ToString();
        //    //}
        //    //else
        //    //{
        //    //    txtTotalIncome.Text = string.Empty;
        //    //}
        //}

        List<Brand> brands = new List<Brand>();
        List<Category> categories = new List<Category>();
        private void InventoryAdd_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM Category", conn);
            SqlDataReader dr = comm.ExecuteReader();
            while(dr.Read())
            {
                cbCategory.Items.Add(dr["Category"]);
                categories.Add(new Category()
                {
                    Category_Id = ((int)dr["Category_Id"]),
                    CategoryName = dr["Category"] as string
                });
            }
            conn.Close();
            conn.Open();
            SqlCommand comm1 = new SqlCommand("SELECT * FROM Brand", conn);
            SqlDataReader dr1 = comm1.ExecuteReader();
            while (dr1.Read())
            {
                brands.Add(new Brand()
                {
                    Brand_Id = ((int)dr1["Brand_Id"]),
                    BrandName = dr1["Brand"] as string,
                    Category_Id = ((int)dr1["Category_Id"])
                });
            }
            conn.Close();
        }


        private string[] GetBrandById(int id)
        {
            return brands.Where(line=>line.Category_Id == id).Select(l=>l.BrandName).ToArray();
        }

        [Serializable]
        class Category
        {
            public int Category_Id { get; set; }
            public string CategoryName { get; set; }
        }
        [Serializable]
        class Brand
        {
            public int Brand_Id { get; set; }
            public string BrandName { get; set; }
            public int Category_Id { get; set; }

        }

        //private void txtQuantity_TextChanged(object sender, EventArgs e)
        //{
        //    MultiplyAndDisplayResult();
        //}

        //private void txtPrice_TextChanged(object sender, EventArgs e)
        //{
        //    MultiplyAndDisplayResult();
        //}
        string cid;
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBrand.Items.Clear();
            int id = categories[cbCategory.SelectedIndex].Category_Id;
            foreach (string name in GetBrandById(id))
            {
                this.cbBrand.Items.Add(name);
            }

            SqlConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            string q = "SELECT Category_Id FROM Category WHERE Category = '" + cbCategory.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cid = dr[0].ToString();
            }
            conn.Close();
        }
        
        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            if (cbCategory.Text == string.Empty || cbBrand.Text == string.Empty)
            {
                MessageBox.Show("Please Select Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtName.Text == string.Empty || txtPrice.Text == string.Empty)
            {
                MessageBox.Show("Please Fill Out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    SqlCommand checkproduct = new SqlCommand("SELECT COUNT(*) FROM Inventory WHERE Name = @Name", conn);
                    checkproduct.Parameters.AddWithValue("@Name", txtName.Text);
                    int productExists = (int)checkproduct.ExecuteScalar();

                    if (productExists > 0)
                    {
                        MessageBox.Show("Product already exists! Please choose a different product name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = "INSERT INTO Inventory (Category, Brand, Name, Price, Re_Order, Category_Id, Brand_Id) VALUES (@Category, @Brand, @Name, @Price, @Re_Order, " + cid + " , " + bid + ")";
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@Category", cbCategory.Text);
                        comm.Parameters.AddWithValue("@Brand", cbBrand.Text);
                        comm.Parameters.AddWithValue("@Name", txtName.Text);
                        comm.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
                        comm.Parameters.AddWithValue("@Re_Order", int.Parse(numericUpDown1.Text));
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                foreach (Form form in Application.OpenForms)
                {
                    if (form is MainForm mainform)
                    {
                        mainform.LoadData();
                        mainform.LoadDataStocks();
                        mainform.LoadData1();
                        mainform.InventoryList();
                        mainform.CriticalStocks();
                        mainform.LoadDashboard();
                    }
                }
                this.Hide();
            }
        }
        string bid;
        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            string q = "SELECT Brand_Id FROM Brand WHERE Brand = '" + cbBrand.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                bid = dr[0].ToString();
            }
            conn.Close();
        }

        private void InventoryAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}

