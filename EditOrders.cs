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
    public partial class EditOrders : MaterialForm
    {
        MainForm mainForm;

        public EditOrders(MainForm mainForm)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);     
            this.mainForm = mainForm;
            this.KeyPreview = true;
        }

        private void EditOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        public string SOStatus
        {
            get { return cbStatus.Text; }
            set { cbStatus.Text = value; }
        }
        public string SONo
        {
            get { return lblId.Text; }
            set { lblId.Text = value; }
        }
        public string SORb
        {
            get { return tbRB.Text; }
            set { tbRB.Text = value; }
        }

        private void EditOrders_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSupplierOrders();

                foreach (Form form in Application.OpenForms)
                {
                    if (form is MainForm mainform)
                    {
                        mainform.LoadDeliveries();
                        mainform.LoadDashboard();
                    }
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblRB.Visible = cbStatus.SelectedItem != null && cbStatus.SelectedItem.ToString() == "Delivered";
                tbRB.Visible = lblRB.Visible;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void UpdateSupplierOrders()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();

                for (int i = 0; i < mainForm.dataDeliveries.Rows.Count; i++)
                {
                    string updateSql = string.Empty;

                    if (cbStatus.Text == "Cancelled")
                    {
                        updateSql = "UPDATE SuppliersOrder SET SO_Status = @SO_Status, SO_Quantity = @SO_Quantity, SO_Price = @SO_Price WHERE SO_No = @SO_No";
                    }
                    else if (cbStatus.Text == "Delivered")
                    {
                        updateSql = "UPDATE SuppliersOrder SET SO_Status = @SO_Status, SO_Received = @SO_Received, SO_ReceivedBy = @SO_ReceivedBy WHERE SO_No = @SO_No";
                    }

                    using (SqlCommand updateComm = new SqlCommand(updateSql, conn))
                    {
                        updateComm.Parameters.AddWithValue("@SO_Status", cbStatus.Text);
                        updateComm.Parameters.AddWithValue("@SO_No", lblId.Text);

                        if (cbStatus.Text == "Cancelled")
                        {
                            updateComm.Parameters.AddWithValue("@SO_Quantity", 0);
                            updateComm.Parameters.AddWithValue("@SO_Price", 0);
                        }
                        else if (cbStatus.Text == "Delivered")
                        {
                            updateComm.Parameters.AddWithValue("@SO_Received", DateTime.Now);
                            updateComm.Parameters.AddWithValue("@SO_ReceivedBy", tbRB.Text);
                        }

                        updateComm.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
