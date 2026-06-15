using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RKS_Inventory
{
    public partial class SupplierProduct : MaterialForm
    {
        MainForm mainform;
        public SupplierProduct(MainForm mainform)
        {
            InitializeComponent();
            InitializeDataGridView(dataSuppProduct);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.KeyPreview = true;
            this.mainform = mainform;
        }
        public string SupplierId
        {
            get { return lblId.Text; }
            set { lblId.Text = value; }
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
        private void SupplierProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rKS_InventoryDataSet.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.rKS_InventoryDataSet.Inventory);
            LoadSuppProduct();
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
            dataSuppProduct.BackgroundColor = Color.White;
            dataSuppProduct.DefaultCellStyle.BackColor = Color.White;
            dataSuppProduct.RowsDefaultCellStyle.ForeColor = Color.Black;
        }
        public void SetDark()
        {
            dataSuppProduct.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataSuppProduct.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataSuppProduct.RowsDefaultCellStyle.ForeColor = Color.White;
            dataSuppProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
        }

        public void LoadSuppProduct()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT * FROM SuppliersProduct WHERE Supplier_Id = '" + lblId.Text + "'";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataSuppProduct.DataSource = dataTable;
                    dataSuppProduct.ClearSelection();
                    dataSuppProduct.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtPrice.Text == string.Empty)
            {
                MessageBox.Show("Please Fill Out!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    SqlCommand checkname = new SqlCommand("SELECT COUNT(*) FROM SuppliersProduct WHERE SP_Name = @Name", conn);
                    checkname.Parameters.AddWithValue("@Name", txtName.Text);
                    int nameExists = (int)checkname.ExecuteScalar();

                    if (nameExists > 0)
                    {
                        MessageBox.Show("Product name already exists! Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = "INSERT INTO SuppliersProduct VALUES (@SP_Name, @SP_Price, @SuppId)";
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@SP_Name", txtName.Text);
                        comm.Parameters.AddWithValue("@SP_Price", int.Parse(txtPrice.Text));
                        comm.Parameters.AddWithValue("@SuppId", lblId.Text);
                        comm.ExecuteNonQuery();
                    }
                    MessageBox.Show("Product has been successfully added!", "Supplier Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtPrice.Clear();
                    LoadSuppProduct();
                    conn.Close();
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
                        mainform.LoadDashboard();
                    }
                }
            }
        }

        private void SupplierProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dataSuppProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataSuppProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit3")
            {
                EditProduct edit = new EditProduct(this);
                edit.SuppId = dataSuppProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                edit.Name = dataSuppProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                edit.Price = dataSuppProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                edit.ShowDialog();
            }
        }
    }
}
