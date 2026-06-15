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
    public partial class Quantity : MaterialForm
    {
        private string productId;
        private double Price;
        private String TransNo;
        private int qty;
        Staff staff;
        public Quantity(Staff staff)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.staff = staff;
            this.KeyPreview = true;
        }
        public void ProductDetails(string productId, int Price, string TransNo, int qty)
        {
            this.productId = productId;
            this.Price = Price;
            this.TransNo = TransNo;
            this.qty = qty;
        }
        private void Quantity_Load(object sender, EventArgs e)
        {
            tbQuantity.SelectAll();
        }

        private void tbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar == (char)13 && !string.IsNullOrEmpty(tbQuantity.Text))
            {
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    try
                    {
                        string id = string.Empty;
                        int cartQty = 0;
                        bool found = false;

                        cn.Open();

                        using (SqlCommand cm = new SqlCommand(
                            "SELECT * FROM Cart WHERE TransactionNo = @TransactionNo AND Product_Id = @Product_Id", cn))
                        {
                            cm.Parameters.AddWithValue("@TransactionNo", TransNo);
                            cm.Parameters.AddWithValue("@Product_Id", productId);

                            using (SqlDataReader dr = cm.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    id = dr["Cart_Id"].ToString();
                                    cartQty = dr["Quantity"] != DBNull.Value ? Convert.ToInt32(dr["Quantity"]) : 0;
                                    found = true;
                                }
                            }
                        }

                        int quantityToAdd = int.Parse(tbQuantity.Text);

                        if (qty < (quantityToAdd + cartQty))
                        {
                            MessageBox.Show($"Unable to Proceed. Remaining Quantity On Hand is {qty}", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        using (SqlCommand cm = new SqlCommand())
                        {
                            cm.Connection = cn;

                            if (found)
                            {
                                cm.CommandText = "UPDATE Cart SET Quantity = Quantity + @Quantity WHERE Cart_Id = @Cart_Id";
                                cm.Parameters.AddWithValue("@Quantity", quantityToAdd);
                                cm.Parameters.AddWithValue("@Cart_Id", id);
                            }
                            else
                            {
                                cm.CommandText = "INSERT INTO Cart (TransactionNo, Price, Quantity, Date, Cashier, Product_Id) " +
                                    "VALUES (@TransactionNo, @Price, @Quantity, @Date, @Cashier, @Product_Id)";
                                cm.Parameters.AddWithValue("@TransactionNo", TransNo);
                                cm.Parameters.AddWithValue("@Price", Price);
                                cm.Parameters.AddWithValue("@Quantity", quantityToAdd);
                                cm.Parameters.AddWithValue("@Date", DateTime.Now);
                                cm.Parameters.AddWithValue("@Cashier", staff.UserSA);
                                cm.Parameters.AddWithValue("@Product_Id", productId);
                            }

                            cm.ExecuteNonQuery();
                        }
                        staff.LoadCart();
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }

        }
        private void OpenStaffForm()
        {
            int quantity;
            if (int.TryParse(tbQuantity.Text, out quantity))
            {
                Staff staff = new Staff();
                staff.SetQuantity(quantity);
                staff.Show();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void Quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
