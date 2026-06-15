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
    public partial class StaffProduct : MaterialForm
    {
        Staff staff;
        public StaffProduct(Staff staff)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ThemeManager.Instance.TheMaterialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.staff = staff;
            this.KeyPreview = true;
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
        
        private void StaffProduct_Load(object sender, EventArgs e)
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
            dataProduct.BackgroundColor = Color.White;
            dataProduct.DefaultCellStyle.BackColor = Color.White;
            dataProduct.RowsDefaultCellStyle.ForeColor = Color.Black;
        }
        public void SetDark()
        {
            dataProduct.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataProduct.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataProduct.RowsDefaultCellStyle.ForeColor = Color.White;
            dataProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void dataProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                Quantity qty = new Quantity(staff);
                qty.ProductDetails(dataProduct.Rows[e.RowIndex].Cells[0].Value.ToString(), int.Parse(dataProduct.Rows[e.RowIndex].Cells[5].Value.ToString()), staff.TransNo, int.Parse(dataProduct.Rows[e.RowIndex].Cells[4].Value.ToString()));
                qty.ShowDialog();
            }
        }
        void Search(string text = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                dataProduct.DataSource = Query("SELECT * FROM Inventory");
            }
            else
            {
                dataProduct.DataSource = Query("SELECT * FROM Inventory where Product_Id LIKE '%{0}%' OR Name LIKE '%{0}%' OR Brand LIKE '%{0}%' OR Category LIKE '%{0}%'", text);
                dataProduct.ClearSelection();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Search(tbSearch.Text);
        }

        private void StaffProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
