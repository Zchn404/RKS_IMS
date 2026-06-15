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
    public partial class InventoryUpdate : MaterialForm
    {
        MainForm mainform;

        public InventoryUpdate(MainForm mainform)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.mainform = mainform;
            this.KeyPreview = true;
        }

        public string ProductId
        {
            get { return tbProductId.Text; }
            set { tbProductId.Text = value; }
        }

        public string Name
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Brand
        {
            get { return tbBrand.Text; }
            set { tbBrand.Text = value; }
        }
        public string Category
        {
            get { return tbCategory.Text; }
            set { tbCategory.Text = value; }
        }

        public string Price
        {
            get { return tbPrice.Text; }
            set { tbPrice.Text = value; }
        }
        public string Reorder
        {
            get { return numericUpDown1.Text; }
            set { numericUpDown1.Text = value; }
        }
        public bool IsCategoryBrand
        {
            set
            {
                tbBrand.Enabled = false;
                tbCategory.Enabled = false;
            }
        }


        private void btnItemUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    SqlCommand checkproduct = new SqlCommand("SELECT COUNT(*) FROM Inventory WHERE Name = @Name AND Product_Id <> @ProductId", conn);
                    checkproduct.Parameters.AddWithValue("@Name", tbName.Text);
                    checkproduct.Parameters.AddWithValue("@ProductId", tbProductId.Text);
                    int productExists = (int)checkproduct.ExecuteScalar();

                    if (productExists > 0)
                    {
                        MessageBox.Show("Product already exists! Please choose a different product name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string updateSql = "UPDATE Inventory SET Name = @Name, Price = @Price, Re_Order = @Re_Order WHERE Product_Id = @ProductId";

                    using (SqlCommand updateComm = new SqlCommand(updateSql, conn))
                    {
                        updateComm.Parameters.AddWithValue("@ProductId", tbProductId.Text);
                        updateComm.Parameters.AddWithValue("@Name", tbName.Text);
                        updateComm.Parameters.AddWithValue("@Price", tbPrice.Text);
                        updateComm.Parameters.AddWithValue("@Re_Order", numericUpDown1.Text);
                        updateComm.ExecuteNonQuery();
                    }
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
                    }
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void InventoryUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void InventoryUpdate_Load(object sender, EventArgs e)
        {

        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
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
