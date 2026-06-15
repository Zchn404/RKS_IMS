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
using System.Windows.Markup;

namespace RKS_Inventory
{
    public partial class SupplierListStaff : MaterialForm
    {
        Staff staff;
        private string referenceNo;
        public SupplierListStaff(Staff staff, string refNo)
        {
            InitializeComponent();
            InitializeDataGridView(dataDeliveries);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.staff = staff;
            referenceNo = refNo;
            LoadProducts();
        }
        private void InitializeDataGridView(DataGridView dataGridView)
        {
            DataGridViewTextBoxColumn numberColumn = new DataGridViewTextBoxColumn();
            numberColumn.HeaderText = "No";
            numberColumn.Name = "NumberColumn";
            numberColumn.ReadOnly = true;
            dataGridView.Columns.Insert(0, numberColumn);

            dataGridView.RowsAdded += new DataGridViewRowsAddedEventHandler((sender, e) => UpdateRowNumbers(dataGridView));
            dataGridView.RowsRemoved += new DataGridViewRowsRemovedEventHandler((sender, e) => UpdateRowNumbers(dataGridView));
        }
        private void UpdateRowNumbers(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["NumberColumn"].Value = (i + 1).ToString();
            }
        }
        public string RefNo
        {
            get { return lblrefno.Text; }
            set { lblrefno.Text = value; }
        }

        private void SupplierListStaff_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }
        public void ApplyTheme()
        {
            var theme = ThemeManager.Instance.TheMaterialSkinManager.Theme;
            if (theme == MaterialSkinManager.Themes.LIGHT)
            {
                SetDataLight();
            }
            else
            {
                SetDark();
            }
        }
        public void SetDataLight()
        {
            dataDeliveries.BackgroundColor = Color.White;
            dataDeliveries.DefaultCellStyle.BackColor = Color.White;
            dataDeliveries.RowsDefaultCellStyle.ForeColor = Color.Black;
        }
        public void SetDark()
        {
            dataDeliveries.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataDeliveries.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataDeliveries.RowsDefaultCellStyle.ForeColor = Color.White;
            dataDeliveries.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
        }

        public void LoadProducts()
        {
            int totalAmount = 0;
            int totalqty = 0;
            string selectSql = @"SELECT SO_Id, SO_Product, SO_Price, SO_Quantity, SO_Total, SO_No, SO_Status 
                         FROM SuppliersOrder 
                         WHERE SO_No = @No AND SO_Status = 'On The Way'";

            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(selectSql, conn);
                    cmd.Parameters.AddWithValue("@No", referenceNo);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        totalAmount += Convert.ToInt32(row["SO_Total"]);
                        totalqty += Convert.ToInt32(row["SO_Quantity"]);
                    }

                    dataDeliveries.DataSource = dt;
                    dataDeliveries.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblOATotal.Text = totalAmount.ToString("###,###,##0");
            lbltotalqty.Text = totalqty.ToString("###,###,##0");
        }
    }
}
