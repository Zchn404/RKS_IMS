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
    public partial class AddSupplier : MaterialForm
    {
        MainForm mainform;
        public AddSupplier(MainForm mainform)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.mainform = mainform;
            this.KeyPreview = true;
        }
        public string SupplierId
        {
            get { return materialLabel6.Text; }
            set { materialLabel6.Text = value; }
        }

        public string Supplier
        {
            get { return tbSName.Text; }
            set { tbSName.Text = value; }
        }
        public string Address
        {
            get { return tbAddress.Text; }
            set { tbAddress.Text = value; }
        }
        public string ContactPerson
        {
            get { return tbContact.Text; }
            set { tbContact.Text = value; }
        }
        public string Phone
        {
            get { return tbPhone.Text; }
            set { tbPhone.Text = value; }
        }
        public string Email
        {
            get { return tbEmail.Text; }
            set { tbEmail.Text = value; }
        }
        public bool IsCategoryEnabled
        {
            set
            {
                materialButton1.Visible = false;
            }
        }
        public bool SupplierAdd
        {
            set
            {
                materialButton3.Visible = false;
            }
        }
        private void AddSupplier_Load(object sender, EventArgs e)
        {
            tbSName.Focus();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (tbSName.Text == string.Empty || tbAddress.Text == string.Empty || tbContact.Text == string.Empty || tbPhone.Text == string.Empty || tbEmail.Text == string.Empty)
            {
                MessageBox.Show("Please fill out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                SqlCommand checksupplier = new SqlCommand("SELECT COUNT(*) FROM Supplier WHERE Supplier = @Supplier", conn);
                checksupplier.Parameters.AddWithValue("@Supplier", tbSName.Text);
                int supplierExists = (int)checksupplier.ExecuteScalar();

                if (supplierExists > 0)
                {
                    MessageBox.Show("Supplier already exists! Please choose a different supplier name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand comm = new SqlCommand("INSERT INTO Supplier VALUES (@Supplier, @Address, @Contact_Person, @Phone, @Email)", conn);
                comm.Parameters.AddWithValue("@Supplier", tbSName.Text);
                comm.Parameters.AddWithValue("@Address", tbAddress.Text);
                comm.Parameters.AddWithValue("@Contact_Person", tbContact.Text);
                comm.Parameters.AddWithValue("@Phone", tbPhone.Text);
                comm.Parameters.AddWithValue("@Email", tbEmail.Text);
                comm.ExecuteNonQuery();
                conn.Close();
                mainform.LoadDataSupplier();
                this.Hide();
            }
            
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    SqlCommand checksupplier = new SqlCommand("SELECT COUNT(*) FROM Supplier WHERE Supplier = @Supplier AND Supplier_Id <> @SupplierId", conn);
                    checksupplier.Parameters.AddWithValue("@Supplier", tbSName.Text);
                    checksupplier.Parameters.AddWithValue("@SupplierId", materialLabel6.Text);
                    int supplierExists = (int)checksupplier.ExecuteScalar();

                    if (supplierExists > 0)
                    {
                        MessageBox.Show("Supplier already exists! Please choose a different supplier name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string updateSql = "UPDATE Supplier SET Supplier = @Supplier, Address = @Address, Contact_Person = @Contact_Person, Phone = @Phone, Email = @Email WHERE Supplier_Id = @SupplierId";

                    using (SqlCommand updateComm = new SqlCommand(updateSql, conn))
                    {
                        updateComm.Parameters.AddWithValue("@SupplierId", materialLabel6.Text);
                        updateComm.Parameters.AddWithValue("@Supplier", tbSName.Text);
                        updateComm.Parameters.AddWithValue("@Address", tbAddress.Text);
                        updateComm.Parameters.AddWithValue("@Contact_Person", tbContact.Text);
                        updateComm.Parameters.AddWithValue("@Phone", tbPhone.Text);
                        updateComm.Parameters.AddWithValue("@Email", tbEmail.Text);
                        updateComm.ExecuteNonQuery();
                    }
                }

                foreach (Form form in Application.OpenForms)
                {
                    if (form is MainForm mainform)
                    {
                        mainform.LoadDataSupplier();
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

        private void AddSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
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
