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
    public partial class ProductStockInStaff : MaterialForm
    {
        private Staff _staff;
        public ProductStockInStaff(Staff staff)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            _staff = staff;
        }

        private void ProductStockInStaff_Load(object sender, EventArgs e)
        {
            this.inventoryTableAdapter.Fill(this.rKS_InventoryDataSet.Inventory);
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
                dataProduct1.DataSource = Query("SELECT * FROM Inventory");
            }
            else
            {
                dataProduct1.DataSource = Query("SELECT * FROM Inventory where Product_Id LIKE '%{0}%' OR Name LIKE '%{0}%'", text);
                dataProduct1.ClearSelection();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Search(tbSearch.Text);
        }
        private HashSet<string> addedProductIds = new HashSet<string>();
        private void dataProduct1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dataProduct1.Columns[e.ColumnIndex].Name;

                if (colName == "Select1")
                {
                    if (string.IsNullOrEmpty(_staff.StockInBy))
                    {
                        MessageBox.Show("Please enter stock in by first!", "In Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Dispose();
                        return;
                    }
                    string productId = dataProduct1.Rows[e.RowIndex].Cells["Product_Id1"].Value.ToString();
                    lblProId.Text = productId;

                    if (addedProductIds.Contains(productId))
                    {
                        MessageBox.Show("This product has already been added.", "In Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Add this item?", "In Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        addStockIn(productId);
                        addedProductIds.Add(productId);
                    }
                }
            }
        }
        public void addStockIn(string productId)
        {
            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand("INSERT INTO Stocks (Reference, StockInDate, StockInBy, Product_Id) VALUES (@Reference, @StockInDate, @StockInBy, @Product_Id)", conn))
                    {
                        DateTime stockInDate;
                        if (!DateTime.TryParse(_staff.DtStock, out stockInDate))
                        {
                            MessageBox.Show("Invalid date format", "In Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        comm.Parameters.AddWithValue("@Reference", _staff.Reference);
                        comm.Parameters.Add("@StockInDate", SqlDbType.DateTime).Value = stockInDate;
                        comm.Parameters.AddWithValue("@StockInBy", _staff.StockInBy);
                        comm.Parameters.AddWithValue("@Product_Id", productId);
                        comm.ExecuteNonQuery();
                    }
                }
                _staff.LoadDataStocks();
                MessageBox.Show("Successfully added", "In Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "In Stock");
            }
        }
    }
}
