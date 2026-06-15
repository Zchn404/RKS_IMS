using MaterialSkin;
using MaterialSkin.Controls;
using Mysqlx.Session;
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
    public partial class Payment : MaterialForm
    {
        Staff staff;
        public Payment(Staff staff)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.staff = staff;
            this.KeyPreview = true;
        }
        public string Sale
        {
            get { return tbSale.Text; }
            set { tbSale.Text = value; }
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            tbCash.Focus();
        }

        private void Payment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            else if (e.KeyCode == Keys.Enter) btnEnter.PerformClick();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnOne.Text;
        }

        private void BtnTwo_Click(object sender, EventArgs e)
        {
            tbCash.Text += BtnTwo.Text;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnThree.Text;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnFour.Text;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnFive.Text;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnSix.Text;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnSeven.Text;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnEight.Text;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnNine.Text;
        }

        private void btnDZero_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnDZero.Text;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            tbCash.Text += btnZero.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbCash.Clear();
            tbCash.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCash.Text) || double.Parse(tbChange.Text) < 0)
            {
                MessageBox.Show("Insufficient amount. Please enter the correct amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();

                    using (SqlCommand updateInventoryCmd = new SqlCommand())
                    using (SqlCommand updateCartCmd = new SqlCommand())
                    {
                        updateInventoryCmd.Connection = cn;
                        updateCartCmd.Connection = cn;

                        for (int i = 0; i < staff.dataStaff.Rows.Count; i++)
                        {
                            updateInventoryCmd.CommandText = "UPDATE Inventory SET Quantity = Quantity - @Quantity WHERE Product_Id = @ProductId";
                            updateInventoryCmd.Parameters.Clear();
                            updateInventoryCmd.Parameters.AddWithValue("@Quantity", int.Parse(staff.dataStaff.Rows[i].Cells[4].Value.ToString()));
                            updateInventoryCmd.Parameters.AddWithValue("@ProductId", staff.dataStaff.Rows[i].Cells[7].Value.ToString());
                            updateInventoryCmd.ExecuteNonQuery();

                            updateCartCmd.CommandText = "UPDATE Cart SET Status = 'Sold' WHERE Cart_Id = @CartId";
                            updateCartCmd.Parameters.Clear();
                            updateCartCmd.Parameters.AddWithValue("@CartId", staff.dataStaff.Rows[i].Cells[1].Value.ToString());
                            updateCartCmd.ExecuteNonQuery();
                        }
                    }
                }

                Receipt receipt = new Receipt(staff);
                receipt.LoadReceipt(tbCash.Text, tbChange.Text);
                receipt.ShowDialog();

                MessageBox.Show("Payment successfully saved!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                staff.GetTranNo();
                staff.LoadCart();
                staff.LoadSold();
                foreach (Form form in Application.OpenForms)
                {
                    if (form is MainForm mainform)
                    {
                        mainform.LoadDashboard();
                    }
                }
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Staff staff)
                    {
                        staff.LoadAdjustment();
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double sale = double.Parse(tbSale.Text);
                double cash = double.Parse(tbCash.Text);
                double charge = cash - sale;
                tbChange.Text = charge.ToString("#,##0");
            }
            catch (Exception)
            {
                tbChange.Text = "0";
            }
        }

        private void tbCash_KeyPress(object sender, KeyPressEventArgs e)
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
