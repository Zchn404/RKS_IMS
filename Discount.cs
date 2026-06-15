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
    public partial class Discount : MaterialForm
    {
        Staff staff;
        public Discount(Staff staff)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            tbDiscount.Focus();
            this.KeyPreview = true;
            this.staff = staff;
        }
        public string labelId
        {
            get { return lblId.Text; }
            set { lblId.Text = value; }
        }
        public string TotalPrice
        {
            get { return tbTotal.Text; }
            set { tbTotal.Text = value; }
        }
        private void Discount_Load(object sender, EventArgs e)
        {

        }

        private void Discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            else if (e.KeyCode == Keys.Enter) btnConfirm.PerformClick();
        }

        private void tbDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double disc = double.Parse(tbTotal.Text) * double.Parse(tbDiscount.Text) * 0.01;
                tbDiscountAmount.Text = disc.ToString("#,##0");
            }
            catch (Exception)
            {
                tbDiscountAmount.Text = "0.00";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                double discountAmount = double.Parse(tbDiscountAmount.Text);
                double totalAmount = double.Parse(tbTotal.Text);

                if (discountAmount > totalAmount)
                {
                    MessageBox.Show("Discount amount cannot be greater than or equal to total amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                if (MessageBox.Show("Add discount? Click yes to confirm", "Discount", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection cn = DatabaseManager.GetConnection())
                    {
                        using (SqlCommand cm = new SqlCommand("UPDATE Cart SET Discount = @Discount WHERE Cart_Id = @Cart_Id", cn))
                        {
                            cn.Open();

                            cm.Parameters.AddWithValue("@Discount", discountAmount);
                            cm.Parameters.AddWithValue("@Cart_Id", int.Parse(lblId.Text));
                            cm.ExecuteNonQuery();
                        }
                    }
                    staff.LoadCart();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void tbDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void tbDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
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
