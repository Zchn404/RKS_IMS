using MaterialSkin;
using MaterialSkin.Controls;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public partial class EditProduct : MaterialForm
    {
        SupplierProduct supplierproduct;
        public EditProduct(SupplierProduct supplierproduct)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);           
            this.supplierproduct = supplierproduct;
            this.KeyPreview = true;
        }
        public string SuppId
        {
            get { return lblid.Text; }
            set { lblid.Text = value; }
        }
        public string Name
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Price
        {
            get { return tbPrice.Text; }
            set { tbPrice.Text = value; }
        }
        private void EditProduct_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    SqlCommand checkname = new SqlCommand("SELECT COUNT(*) FROM SuppliersProduct WHERE SP_Name = @Name AND SP_Id <> @CurrentId", conn);
                    checkname.Parameters.AddWithValue("@Name", tbName.Text);
                    checkname.Parameters.AddWithValue("@CurrentId", lblid.Text);
                    int nameExists = (int)checkname.ExecuteScalar();

                    if (nameExists > 0)
                    {
                        MessageBox.Show("This product name already exists! Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string updateSql = "UPDATE SuppliersProduct SET SP_Name = @SP_Name, SP_Price = @SP_Price WHERE SP_Id = @SP_Id";

                    using (SqlCommand updateComm = new SqlCommand(updateSql, conn))
                    {
                        updateComm.Parameters.AddWithValue("@SP_Id", lblid.Text);
                        updateComm.Parameters.AddWithValue("@SP_Name", tbName.Text);
                        updateComm.Parameters.AddWithValue("@SP_Price", tbPrice.Text);
                        updateComm.ExecuteNonQuery();
                    }
                }
                foreach (Form form in Application.OpenForms)
                {
                    if (form is SupplierProduct supplierproduct)
                    {
                        supplierproduct.LoadSuppProduct();
                    }
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
