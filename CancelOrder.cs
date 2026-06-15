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
    public partial class CancelOrder : MaterialForm
    {
        Staff staff;
        public CancelOrder(Staff staff)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.staff = staff;
            this.KeyPreview = true;
        }
        public string CartId
        {
            get { return tbCId.Text; }
            set { tbCId.Text = value; }
        }
        public string TransactionNo
        {
            get { return tbCTrans.Text; }
            set { tbCTrans.Text = value; }
        }
        public string CartName
        {
            get { return tbCName.Text; }
            set { tbCName.Text = value; }
        }
        public string CartPrice
        {
            get { return tbCPrice.Text; }
            set { tbCPrice.Text = value; }
        }
        public string CartQuantity
        {
            get { return tbCQuantity.Text; }
            set { tbCQuantity.Text = value; }
        }
        public string CartDiscount
        {
            get { return tbCDiscount.Text; }
            set { tbCDiscount.Text = value; }
        }
        public string CartTotal
        {
            get { return tbCTotal.Text; }
            set { tbCTotal.Text = value; }
        }
        public string CartProductId
        {
            get { return lblpid.Text; }
            set { lblpid.Text = value; }
        }
        public string VoidBy
        {
            get { return tbCVoidby.Text; }
            set { tbCVoidby.Text = value; }
        }
        public string UserVoid
        {
            get { return lbluser.Text; }
            set { lbluser.Text = value; }
        }

        private void CancelOrder_Load(object sender, EventArgs e)
        {

        }

        private void btnVoidO_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCAction.Text == string.Empty || udCancelQuantity.Value <= 0 || tbCReason.Text == string.Empty)
                {
                    MessageBox.Show("Please fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int cartQuantity;
                if (!int.TryParse(tbCQuantity.Text, out cartQuantity))
                {
                    MessageBox.Show("Invalid cart quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (udCancelQuantity.Value > cartQuantity)
                {
                    MessageBox.Show("The cancel quantity is more than the cart quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cartQuantity >= udCancelQuantity.Value)
                {
                    Void @void = new Void(this);
                    @void.tbUser.Focus();
                    @void.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void CancelOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
