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
    public partial class Void : MaterialForm
    {
        private CancelOrder cancelOrder;
        public Void(CancelOrder cancelOrder)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.cancelOrder = cancelOrder;
        }

        private void Void_Load(object sender, EventArgs e)
        {

        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    string user = string.Empty;
                    string role = string.Empty;

                    SqlCommand cm = new SqlCommand("SELECT * FROM [User] WHERE Username = @Username", cn);
                    cm.Parameters.AddWithValue("@Username", tbUser.Text);

                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            user = dr["Username"].ToString();
                            string storedEncryptedPassword = dr["Password"].ToString();
                            role = dr["Role"].ToString();
                            string userInputPassword = tbPass.Text;

                            string decryptedPassword = EncryptionHelper.Decrypt(storedEncryptedPassword);


                            if (decryptedPassword != userInputPassword)
                            {
                                MessageBox.Show("Incorrect Username or Password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Hide();
                                return;
                            }

 
                            if (role != "Administrator")
                            {
                                MessageBox.Show("Only Administrators can void items.", "Authorization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Hide();
                                return;
                            }

                            var confirmationResult = MessageBox.Show(
                                "Are you sure you want to void this item?",
                                "Confirm Void",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (confirmationResult == DialogResult.No)
                            {
                                this.Hide();
                                return;
                            }

                            if (cancelOrder.cbCAction.Text == "Yes")
                            {
                                UpdateData(
                                    "UPDATE Inventory SET Quantity = Quantity + @Quantity WHERE Product_Id = @Product_Id",
                                    new SqlParameter("@Quantity", cancelOrder.udCancelQuantity.Value),
                                    new SqlParameter("@Product_Id", cancelOrder.lblpid.Text)
                                );
                            }

                            UpdateData(
                                "UPDATE Cart SET Quantity = Quantity - @Quantity WHERE Cart_Id = @Cart_Id",
                                new SqlParameter("@Quantity", cancelOrder.udCancelQuantity.Value),
                                new SqlParameter("@Cart_Id", cancelOrder.tbCId.Text)
                            );

                            MessageBox.Show(
                                "Order transaction successfully cancelled!",
                                "Cancel Order",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            SaveCancelOrder(user);
                            cancelOrder.Hide();
                            this.Hide();

                            foreach (Form form in Application.OpenForms)
                            {
                                if (form is Staff staff)
                                {
                                    staff.LoadCart();
                                    staff.LoadAdjustment();
                                    staff.LoadSold();
                                }
                            }
                        }
                        else if (string.IsNullOrEmpty(tbUser.Text) || string.IsNullOrEmpty(tbPass.Text))
                        {
                            MessageBox.Show("Please Input Username and Password!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username or Password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Hide();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         public void SaveCancelOrder(string user)
        {
            try
            {
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand("INSERT INTO Cancel (TransactionNo, Price, Quantity, Date, VoidBy, CancelledBy, Reason, Action) VALUES (@TransactionNo, @Price, @Quantity, @Date, @VoidBy, @CancelledBy, @Reason, @Action)", cn))
                    {
                        cm.Parameters.AddWithValue("@TransactionNo", cancelOrder.tbCTrans.Text);
                        cm.Parameters.AddWithValue("@Price", cancelOrder.tbCPrice.Text);
                        cm.Parameters.AddWithValue("@Quantity", cancelOrder.udCancelQuantity.Value);
                        cm.Parameters.AddWithValue("@Date", DateTime.Now);
                        cm.Parameters.AddWithValue("@VoidBy", cancelOrder.tbCVoidby.Text);
                        cm.Parameters.AddWithValue("@CancelledBy", user);
                        cm.Parameters.AddWithValue("@Reason", cancelOrder.tbCReason.Text);
                        cm.Parameters.AddWithValue("@Action", cancelOrder.cbCAction.Text);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateData(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection cn = DatabaseManager.GetConnection())
            {
                using (SqlCommand cm = new SqlCommand(sql, cn))
                {
                    cm.Parameters.AddRange(parameters);
                    cn.Open();
                    cm.ExecuteNonQuery();
                }
            }
        }

        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnVoid.PerformClick();
            }
        }
    }
}
