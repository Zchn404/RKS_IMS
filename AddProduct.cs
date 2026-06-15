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

namespace RKS_Inventory
{
    public partial class AddProduct : MaterialForm
    {
        private MainForm _mainForm;
        private string supIdText1;
        public AddProduct(MainForm mainform, string supIdText)
        {
            InitializeComponent();
            InitializeDataGridView(dataProduct1);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            _mainForm = mainform;
            supIdText1 = supIdText;
            LoadSuppProduct();
            ApplyTheme();
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
            dataProduct1.BackgroundColor = Color.White;
            dataProduct1.DefaultCellStyle.BackColor = Color.White;
            dataProduct1.RowsDefaultCellStyle.ForeColor = Color.Black;
        }
        public void SetDark()
        {
            dataProduct1.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataProduct1.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataProduct1.RowsDefaultCellStyle.ForeColor = Color.White;
            dataProduct1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
        }
        private HashSet<string> addedProductIds = new HashSet<string>();

        DataTable Query(string command, params object[] data)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = DatabaseManager.GetConnection())
            {
                SqlCommand comm = new SqlCommand(string.Format(command, data), cn);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(dt);
            }
            return dt;
        }
        void Search(string text = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                dataProduct1.DataSource = Query("SELECT * FROM SuppliersProduct WHERE Supplier_Id = "+ supIdText1 + "");
            }
            else
            {
                dataProduct1.DataSource = Query("SELECT * FROM SuppliersProduct WHERE SP_Name LIKE '%{0}%' AND Supplier_Id = "+ supIdText1 +"", text);
                dataProduct1.ClearSelection();
            }
        }
        private void AddProduct_Load(object sender, EventArgs e)
        {
            this.suppliersProductTableAdapter.Fill(this.rKS_InventoryDataSet.SuppliersProduct);
        }

        private void dataProduct1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dataProduct1.Columns[e.ColumnIndex].Name;

                if (colName == "Select1")
                {
                    if (string.IsNullOrEmpty(_mainForm.cbaosupp))
                    {
                        MessageBox.Show("Please select supplier first!", "Supplier's Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Dispose();
                        return;
                    }
                    string suppId = dataProduct1.Rows[e.RowIndex].Cells["SP_Id1"].Value.ToString();
                    lblProId.Text = suppId;

                    if (addedProductIds.Contains(suppId))
                    {
                        MessageBox.Show("This product has already been added.", "Supplier's Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Add this item?", "Supplier's Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        addProducts(suppId);
                        addedProductIds.Add(suppId);
                    }
                }
            }
        }
        public void addProducts(string suppId)
        {
            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand("INSERT INTO SuppliersOrder (SO_No, SO_OrderBy, SO_Created, SO_Supplier, SO_Product, SO_Price, Supplier_Id) VALUES (@SO_No, @SO_OrderBy, @SO_Created, @SO_Supplier, @SO_Product, @SO_Price, @Supplier_Id)", conn))
                    {
                        comm.Parameters.AddWithValue("@SO_No", _mainForm.ReferenceAo);
                        comm.Parameters.AddWithValue("@SO_OrderBy", _mainForm.OrderBy);
                        comm.Parameters.AddWithValue("@SO_Created", DateTime.Now);
                        comm.Parameters.AddWithValue("@SO_Supplier", _mainForm.cbaosupp);
                        comm.Parameters.AddWithValue("@SO_Product", dataProduct1.CurrentRow.Cells[2].Value.ToString());
                        comm.Parameters.AddWithValue("@SO_Price", dataProduct1.CurrentRow.Cells[3].Value.ToString());
                        comm.Parameters.AddWithValue("@Supplier_Id", supIdText1);
                        comm.ExecuteNonQuery();
                    }
                }
                _mainForm.LoadProducts();
                MessageBox.Show("Successfully added", "Supplier's Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Supplier's Product");
            }
        }
        public void LoadSuppProduct()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT * FROM SuppliersProduct WHERE Supplier_Id = @SupplierId";

                using (SqlCommand command = new SqlCommand(selectSql, conn))
                {
                    command.Parameters.AddWithValue("@SupplierId", supIdText1); 

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataProduct1.DataSource = dataTable;
                        dataProduct1.ClearSelection();
                        dataProduct1.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Search(tbSearch.Text);
        }
    }
}
