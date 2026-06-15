using MaterialSkin;
using MaterialSkin.Controls;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Markup;
using System.Xml.Linq;
using System.Xml.XPath;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RKS_Inventory
{
    public partial class MainForm : MaterialForm
    {
        SqlConnection cn = DatabaseManager.GetConnection();
        SqlCommand cm = new SqlCommand();
        MaterialSkinManager Tmanager = MaterialSkinManager.Instance;
        MainForm main;
        public string _pass;
        string accstatus;
        private bool isDarkMode = false;

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
        public MainForm()
        {
            InitializeComponent();

            InitializeDataGridView(dataInventory);
            InitializeDataGridView(dataBrand);
            InitializeDataGridView(dataCategory);
            InitializeDataGridView(dataStocks);
            InitializeDataGridView(dataAdjustment);
            InitializeDataGridView(dataSupplier);
            InitializeDataGridView(dataOrders);
            InitializeDataGridView(dataDeliveries);
            InitializeDataGridView1(dataUser);


            var themeManager = ThemeManager.Instance;
            themeManager.TheMaterialSkinManager.AddFormToManage(this);
            themeManager.SetTheme(MaterialSkinManager.Themes.LIGHT);
            dataInventory.DataSource = Query("SELECT * FROM Inventory");
            dataStocks.DataSource = Query("SELECT * FROM Stocks");
            dataBrand.DataSource = Query("SELECT * FROM Brand");
            dataCategory.DataSource = Query("SELECT * FROM Category");
            dataSupplier.DataSource = Query("SELECT * FROM Supplier");
            dataUser.DataSource = Query("SELECT * FROM [User]");
            materialTextBox1.TextChanged += MaterialTextBox1_TextChanged;
            materialTextBox3.TextChanged += MaterialTextBox3_TextChanged;
            materialTextBox4.TextChanged += MaterialTextBox4_TextChanged;
            materialTextBox5.TextChanged += MaterialTextBox5_TextChanged;
            materialTextBox16.TextChanged += MaterialTextBox16_TextChanged;
            tbSearchSA.TextChanged += TbSearchSA_TextChanged;
            materialTabControl1.SelectedIndexChanged += MaterialTabControl1_SelectedIndexChanged;
            StockInBy = lblUsername.Text;
            LoadData();
            LoadData1();
            LoadDataStocks();
            LoadDataBrand();
            LoadDataCategory();
            LoadDataSupplier();
            //LoadSupplier();
            LoadCategory();
            LoadCSupplier();
            LoadOrderProduct();
            LoadDeliveries();
            LoadProducts();
            //LoadAOSupplier();
            GetRefeNo();
            ReferenceNo();
            RefNo();
            InventoryList();
            CriticalStocks();
            LoadDashboard();
            LoadChartTopSellingDashboard();
            LoadChartTopSellingQuantityDashboard();
            LoadChartYearlyDashboard();
            lblDate.Text = DateTime.Now.ToShortDateString();
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
        private void InitializeDataGridView1(DataGridView dataGridView)
        {
            DataGridViewTextBoxColumn numberColumn = new DataGridViewTextBoxColumn();
            numberColumn.HeaderText = "No";
            numberColumn.Name = "NumberColumn";
            numberColumn.ReadOnly = true;
            dataGridView.Columns.Insert(0, numberColumn);

            dataGridView.RowsAdded += new DataGridViewRowsAddedEventHandler((sender, e) => UpdateRowNumbers1(dataGridView));
            dataGridView.RowsRemoved += new DataGridViewRowsRemovedEventHandler((sender, e) => UpdateRowNumbers1(dataGridView));
        }
        
        private void UpdateRowNumbers1(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["NumberColumn"].Value = (1901 + i).ToString();
            }
        }
        private void TbSearchSA_TextChanged(object sender, EventArgs e)
        {
            Search6(tbSearchSA.Text);
        }

        //public void LoadSupplier()
        //{
        //    string query = "SELECT * FROM Supplier";
        //    try
        //    {
        //        using (SqlConnection cn = DatabaseManager.GetConnection())
        //        {
        //            cn.Open();
        //            using (SqlCommand cmd = new SqlCommand(query, cn))
        //            {
        //                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //                {
        //                    DataTable dataTable = new DataTable();
        //                    adapter.Fill(dataTable);

        //                    DataRow emptyRow = dataTable.NewRow();
        //                    emptyRow["Supplier"] = "";
        //                    dataTable.Rows.InsertAt(emptyRow, 0);

        //                    cbSupp.DataSource = dataTable;
        //                    cbSupp.DisplayMember = "Supplier";
        //                    cbSupp.SelectedIndex = 0;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //}

        private void cbSupp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string StockInBy
        {
            get { return tbStockInBy.Text; }
            set { tbStockInBy.Text = value; }
        }
        public string Reference
        {
            get { return lblReference.Text; }
            set { lblReference.Text = value; }
        }
        
        public string DtStock
        {
            get { return dtStockIn.Text; }
            set { dtStockIn.Text = value; }
        }
        

        public string labelUserMain
        {
            get { return lblUser.Text; }
            set { lblUser.Text = value; }
        }
        public string labelUserMain1
        {
            get { return lblUser1.Text; }
            set { lblUser1.Text = value; }
        }
        public string labelRoleMain
        {
            get { return lblRole.Text; }
            set { lblRole.Text = value; }
        }
        public string labelResetMain
        {
            get { return lblUsername.Text; }
            set { lblUsername.Text = value; }
        }
        public string StockInByy
        {
            get { return tbStockInBy.Text; }
            set { tbStockInBy.Text = value; }
        }
        public string UserSA
        {
            get { return lblUserSA.Text; }
            set { lblUserSA.Text = value; }
        }


        public string cbaosupp
        {
            get { return cbAOSupp.Text; }
            set { cbAOSupp.Text = value; }
        }
        public string ReferenceAo
        {
            get { return lblNo.Text; }
            set { lblNo.Text = value; }
        }
        public string OrderBy
        {
            get { return lblUserSA.Text; }
            set { lblUserSA.Text = value; }
        }
        private void MaterialTextBox16_TextChanged(object sender, EventArgs e)
        {
            Search5(materialTextBox16.Text);
        }

        private void MaterialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab.Text == "Logout")
            {
                Logout();

                DateTime now = DateTime.Now;
                TimeSpan currentTime = now.TimeOfDay;

                using (SqlConnection connection = DatabaseManager.GetConnection())
                {
                    connection.Open();
                    string insertLogoutQuery = "INSERT INTO AccessLogs ([User], Date, TimeOut, Action) VALUES (@User, @Date, @TimeOut, 'Logout')";

                    using (SqlCommand command = new SqlCommand(insertLogoutQuery, connection))
                    {
                        command.Parameters.AddWithValue("@User", UserSA);
                        command.Parameters.AddWithValue("@Date", now.Date);
                        command.Parameters.AddWithValue("@TimeOut", currentTime);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        private void Logout()
        {         
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
        private void MaterialTextBox5_TextChanged(object sender, EventArgs e)
        {
            Search4(materialTextBox5.Text);
        }

        private void MaterialTextBox4_TextChanged(object sender, EventArgs e)
        {
            Search3(materialTextBox4.Text);
        }

        private void MaterialTextBox3_TextChanged(object sender, EventArgs e)
        {
            Search2(materialTextBox3.Text);
        }

        private void MaterialTextBox1_TextChanged(object sender, EventArgs e)
        {
            Search(materialTextBox1.Text);
        }

        public void LoadData()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT * FROM Inventory";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataInventory.DataSource = dataTable;
                    dataInventory.ClearSelection();
                    SortByIdColumn();
                    dataInventory.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private void SortByIdColumn()
        {
            if (dataInventory.Columns["Id"] != null)
            {
                dataInventory.Sort(dataInventory.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        public void LoadData1()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT Product_Id, Name, Brand, Category, Price, Quantity FROM Inventory";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataAdjustment.DataSource = dataTable;
                    dataAdjustment.ClearSelection();
                    SortByIdColumn6();
                    dataAdjustment.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private void SortByIdColumn6()
        {
            if (dataAdjustment.Columns["Id"] != null)
            {
                dataAdjustment.Sort(dataAdjustment.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        public void LoadDataStocks()
        {
            string selectSql = @"
        SELECT s.Stock_Id, s.Reference, i.Name, s.Quantity, s.StockInDate, s.StockInBy, s.Product_Id
        FROM Stocks s 
        INNER JOIN Inventory i ON s.Product_Id = i.Product_Id
        WHERE s.Reference LIKE @Reference AND s.Status LIKE 'Pending'";

            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(selectSql, conn);
                    cmd.Parameters.AddWithValue("@Reference", "%" + lblReference.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataStocks.DataSource = dt;
                    SortByIdColumn1();
                    dataStocks.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SortByIdColumn1()
        {
            if (dataStocks.Columns["Id"] != null)
            {
                dataStocks.Sort(dataStocks.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        public void LoadDataBrand()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT b.Brand_Id, b.Brand, b.Category_Id, c.Category FROM Brand b INNER JOIN Category c ON b.Category_Id = c.Category_Id";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataBrand.DataSource = dataTable;
                    dataBrand.ClearSelection();
                    SortByIdColumn2();
                    dataBrand.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private void SortByIdColumn2()
        {
            if (dataBrand.Columns["Id"] != null)
            {
                dataBrand.Sort(dataBrand.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        public void LoadDataCategory()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT * FROM Category";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataCategory.DataSource = dataTable;
                    dataCategory.ClearSelection();
                    SortByIdColumn3();
                    dataCategory.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private void SortByIdColumn3()
        {
            if (dataCategory.Columns["Id"] != null)
            {
                dataCategory.Sort(dataCategory.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        public void LoadDataSupplier()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT * FROM Supplier";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataSupplier.DataSource = dataTable;
                    dataSupplier.ClearSelection();
                    SortByIdColumn4();
                    dataSupplier.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private void SortByIdColumn4()
        {
            if (dataSupplier.Columns["Id"] != null)
            {
                dataSupplier.Sort(dataSupplier.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        public void LoadDataUser()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT * FROM [User]";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataUser.DataSource = dataTable;
                    dataUser.ClearSelection();
                    SortByIdColumn5();
                    dataUser.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private void SortByIdColumn5()
        {
            if (dataUser.Columns["Id"] != null)
            {
                dataUser.Sort(dataSupplier.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.suppliersOrderTableAdapter.Fill(this.rKS_InventoryDataSet1.SuppliersOrder);
            this.dataTable1TableAdapter.Fill(this.rKS_InventoryDataSet.DataTable1);
            this.AutoSize = false;
            this.adjustTableAdapter.Fill(this.rKS_InventoryDataSet.Adjust);
            this.userTableAdapter.Fill(this.rKS_InventoryDataSet.User);
            this.stocksTableAdapter.Fill(this.rKS_InventoryDataSet.Stocks);
            this.categoryTableAdapter.Fill(this.rKS_InventoryDataSet.Category);
            this.brandTableAdapter.Fill(this.rKS_InventoryDataSet.Brand);
            this.inventoryTableAdapter.Fill(this.rKS_InventoryDataSet.Inventory);
            dataStocks.DataSource = null;
            dataStockInHistory.DataSource = null;
            dataAdjustmentHistory.DataSource = null;
            dataStockInSH.DataSource = null;
            dataOrders.DataSource = null;
            Noti();
            LoadProduct();
        }

        public void LoadDashboard()
        {
            lblTStaff.Text = GetTotalStaff().ToString("###,###,##0");
            lblTProd.Text = GetTotalProducts().ToString("###,###,##0");
            lblTSOH.Text = GetStockOnHand().ToString("###,###,##0");
            lblCritical.Text = GetCriticalItems().ToString("###,###,##0");
            lblDST.Text = GetDailySales().ToString("###,###,##0");
            lblIncoming.Text = IncomingDelivery().ToString("###,###,##0");
        }
        private int GetTotalStaff()
        {
            string query = "SELECT COUNT(*) AS Staff FROM [User] WHERE Role LIKE '%Staff%' AND Status = 'Active'";
            return Convert.ToInt32(ExecuteScalarQuery(query));
        }

        private int GetTotalProducts()
        {
            string query = "SELECT COUNT(*) FROM Inventory";
            return Convert.ToInt32(ExecuteScalarQuery(query));
        }

        private int GetStockOnHand()
        {
            string query = "SELECT ISNULL(SUM(Quantity), 0) AS qty FROM Inventory";
            return Convert.ToInt32(ExecuteScalarQuery(query));
        }

        private int GetCriticalItems()
        {
            string query = "SELECT COUNT(*) FROM vwCriticalItems";
            return Convert.ToInt32(ExecuteScalarQuery(query));
        }
        private int GetDailySales()
        {
            DateTime currentDate = DateTime.Today;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            string query = $"SELECT ISNULL(SUM(Total), 0) AS total FROM vwCart WHERE Date = '{formattedDate}' AND Status = 'Sold'";
            return Convert.ToInt32(ExecuteScalarQuery(query));
        }
        private int IncomingDelivery()
        {
            string query = "SELECT COUNT(DISTINCT SO_No) AS Deliveries FROM SuppliersOrder WHERE SO_Status = 'On The Way'";
            return Convert.ToInt32(ExecuteScalarQuery(query));
        }
        private object ExecuteScalarQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = DatabaseManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        public void LoadChartTopSellingQuantityDashboard()
        {
            var yearlyQuantities = new Dictionary<string, int>();

            using (SqlConnection cn = DatabaseManager.GetConnection())
            {
                cn.Open();
                string query = "SELECT Name, Quantity, Date FROM vwCart WHERE Status = 'Sold'";

                using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "SalesData");

                    foreach (DataRow row in ds.Tables["SalesData"].Rows)
                    {
                        if (row["Date"] is DateTime saleDate &&
                            row["Name"] is string itemName &&
                            row["Quantity"] is int quantity)
                        {
                            if (saleDate.Year == DateTime.Now.Year)
                            {
                                if (!yearlyQuantities.ContainsKey(itemName))
                                {
                                    yearlyQuantities[itemName] = 0;
                                }
                                yearlyQuantities[itemName] += quantity;
                            }
                        }
                    }
                }
            }

            var topSellingQuantities = yearlyQuantities.OrderByDescending(kv => kv.Value).Take(5).ToList();

            chart1.Series[0].Points.Clear();
            foreach (var item in topSellingQuantities)
            {
                chart1.Series[0].Points.AddXY(item.Key, item.Value);
            }

            chart1.Series[0].Name = "YEARLY TOP SELLING QUANTITY";
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            chart1.Series[0].LabelFormat = "{###,###,##0}";
            chart1.Series[0].IsValueShownAsLabel = true;
        }
        public void LoadChartTopSellingDashboard()
        {
            var yearlyTotals = new Dictionary<string, int>();

            using (SqlConnection cn = DatabaseManager.GetConnection())
            {
                cn.Open();
                string query = "SELECT Name, Total, Date FROM vwCart WHERE Status = 'Sold'";

                using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "SalesData");

                    foreach (DataRow row in ds.Tables["SalesData"].Rows)
                    {
                        if (row["Date"] is DateTime saleDate &&
                            row["Name"] is string itemName &&
                            row["Total"] is int total)
                        {
                            if (saleDate.Year == DateTime.Now.Year)
                            {
                                if (!yearlyTotals.ContainsKey(itemName))
                                {
                                    yearlyTotals[itemName] = 0;
                                }
                                yearlyTotals[itemName] += total;
                            }
                        }
                    }
                }
            }

            var topSellingTotals = yearlyTotals.OrderByDescending(kv => kv.Value).Take(5).ToList();

            chart2.Series[0].Points.Clear();
            foreach (var item in topSellingTotals)
            {
                chart2.Series[0].Points.AddXY(item.Key, item.Value);
            }

            chart2.Series[0].Name = "YEARLY TOP SELLING TOTAL";
            chart2.Series[0].ChartType = SeriesChartType.Doughnut;
            chart2.Series[0].LabelFormat = "{###,###,##0}";
            chart2.Series[0].IsValueShownAsLabel = true;
        }
        public void LoadChartYearlyDashboard()
        {
            using (SqlConnection cn = DatabaseManager.GetConnection())
            {
                cn.Open();

                string query = string.Empty;

                query = "SELECT Year(Date) as Year, ISNULL(SUM(Total), 0) AS Total FROM vwCart WHERE Status LIKE 'Sold' GROUP BY YEAR(Date) ORDER BY Total DESC";

                using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Sales");

                    chart3.DataSource = ds.Tables["Sales"];
                    Series series = chart3.Series[0];
                    series.ChartType = SeriesChartType.Pyramid;

                    series.Name = "Total Sales";
                    chart3.Series[0].XValueMember = "Year";
                    chart3.Series[0].YValueMembers = "Total";
                    chart3.Series[0].LabelFormat = "{###,###,##0}";
                    chart3.Series[0].IsValueShownAsLabel = true;
                }
            }
        }
        void Search(string text = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                dataInventory.DataSource = Query("SELECT * FROM Inventory");
            }
            else
            {
                dataInventory.DataSource = Query("SELECT * FROM Inventory where Name LIKE '%{0}%' OR Brand LIKE '%{0}%' OR Category LIKE '%{0}%'", text);
                dataInventory.ClearSelection();
            }
        }
        void Search2(string text = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                dataBrand.DataSource = Query("SELECT b.Brand_Id, b.Brand, b.Category_Id, c.Category FROM Brand b INNER JOIN Category c ON b.Category_Id = c.Category_Id");
            }
            else
            {
                dataBrand.DataSource = Query("SELECT b.Brand_Id, b.Brand, b.Category_Id, c.Category FROM Brand b INNER JOIN Category c ON b.Category_Id = c.Category_Id where b.Brand LIKE '%{0}%' OR c.Category LIKE '%{0}%'", text);
                dataBrand.ClearSelection();
            }
        }
        void Search3(string text = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                dataCategory.DataSource = Query("SELECT * FROM Category");
            }
            else
            {
                dataCategory.DataSource = Query("SELECT * FROM Category where Category LIKE '%{0}%'", text);
                dataCategory.ClearSelection();
            }
        }
        void Search4(string text = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                dataSupplier.DataSource = Query("SELECT * FROM Supplier");
            }
            else
            {
                dataSupplier.DataSource = Query("SELECT * FROM Supplier where Supplier LIKE '%{0}%' OR Contact_Person LIKE '%{0}%' ", text);
                dataSupplier.ClearSelection();
            }
        }
        void Search5(string text = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                dataUser.DataSource = Query("SELECT * FROM [User]");
            }
            else
            {
                dataUser.DataSource = Query("SELECT * FROM [User] where Username LIKE '%{0}%' OR FullName LIKE '%{0}%' OR Role LIKE '%{0}%'", text);
                dataUser.ClearSelection();
            }
        }
        void Search6(string text = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                dataAdjustment.DataSource = Query("SELECT * FROM Inventory");
            }
            else
            {
                dataAdjustment.DataSource = Query("SELECT * FROM Inventory where Name LIKE '%{0}%' OR Brand LIKE '%{0}%' OR Category LIKE '%{0}%'", text);
                dataAdjustment.ClearSelection();
            }
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            isDarkMode = false;
            materialButton2.BringToFront();
            ThemeManager.Instance.SetTheme(MaterialSkinManager.Themes.LIGHT);
            dataInventory.BackgroundColor = Color.White;
            dataInventory.DefaultCellStyle.BackColor = Color.White;
            dataInventory.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataInventory.Invalidate();

            dataStocks.BackgroundColor = Color.White;
            dataStocks.DefaultCellStyle.BackColor = Color.White;
            dataStocks.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataStocks.Invalidate();

            dataBrand.BackgroundColor = Color.White;
            dataBrand.DefaultCellStyle.BackColor = Color.White;
            dataBrand.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataBrand.Invalidate();

            dataCategory.BackgroundColor = Color.White;
            dataCategory.DefaultCellStyle.BackColor = Color.White;
            dataCategory.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataCategory.Invalidate();

            dataSupplier.BackgroundColor = Color.White;
            dataSupplier.DefaultCellStyle.BackColor = Color.White;
            dataSupplier.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataSupplier.Invalidate();

            dataUser.BackgroundColor = Color.White;
            dataUser.DefaultCellStyle.BackColor = Color.White;
            dataUser.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataUser.Invalidate();

            dataStockInHistory.BackgroundColor = Color.White;
            dataStockInHistory.DefaultCellStyle.BackColor = Color.White;
            dataStockInHistory.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataStockInHistory.Invalidate();

            dataAdjustment.BackgroundColor = Color.White;
            dataAdjustment.DefaultCellStyle.BackColor = Color.White;
            dataAdjustment.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataAdjustment.Invalidate();

            dataAdjustmentHistory.BackgroundColor = Color.White;
            dataAdjustmentHistory.DefaultCellStyle.BackColor = Color.White;
            dataAdjustmentHistory.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataAdjustmentHistory.Invalidate();

            dataInvetoryList.BackgroundColor = Color.White;
            dataInvetoryList.DefaultCellStyle.BackColor = Color.White;
            dataInvetoryList.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataInvetoryList.Invalidate();

            dataCriticalStocks.BackgroundColor = Color.White;
            dataCriticalStocks.DefaultCellStyle.BackColor = Color.White;
            dataCriticalStocks.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataCriticalStocks.Invalidate();

            dataStockInSH.BackgroundColor = Color.White;
            dataStockInSH.DefaultCellStyle.BackColor = Color.White;
            dataStockInSH.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataStockInSH.Invalidate();

            dataSalesHistory.BackgroundColor = Color.White;
            dataSalesHistory.DefaultCellStyle.BackColor = Color.White;
            dataSalesHistory.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataSalesHistory.Invalidate();

            dataTopSelling.BackgroundColor = Color.White;
            dataTopSelling.DefaultCellStyle.BackColor = Color.White;
            dataTopSelling.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataTopSelling.Invalidate();

            dataCancelled.BackgroundColor = Color.White;
            dataCancelled.DefaultCellStyle.BackColor = Color.White;
            dataCancelled.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataCancelled.Invalidate();

            dataOrders.BackgroundColor = Color.White;
            dataOrders.DefaultCellStyle.BackColor = Color.White;
            dataOrders.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataOrders.Invalidate();

            dataDeliveries.BackgroundColor = Color.White;
            dataDeliveries.DefaultCellStyle.BackColor = Color.White;
            dataDeliveries.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataDeliveries.Invalidate();

            dataOrderHistory.BackgroundColor = Color.White;
            dataOrderHistory.DefaultCellStyle.BackColor = Color.White;
            dataOrderHistory.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataOrderHistory.Invalidate();

            dataAccessLogs.BackgroundColor = Color.White;
            dataAccessLogs.DefaultCellStyle.BackColor = Color.White;
            dataAccessLogs.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataAccessLogs.Invalidate();

            var legend = chart1.Legends[0];
            legend.ForeColor = System.Drawing.Color.Black;
            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.TitleForeColor = System.Drawing.Color.Black;
            chartArea.AxisY.TitleForeColor = System.Drawing.Color.Black;
            chartArea.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Black;
            chartArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Black;
            var series = chart1.Series[0];
            series.LabelForeColor = Color.Black;
            var title = chart1.Titles[0];
            title.ForeColor = System.Drawing.Color.Black;
            var legend1 = chart2.Legends[0];
            legend1.ForeColor = System.Drawing.Color.Black;
            var chartArea1 = chart2.ChartAreas[0];
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Black;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Black;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Black;
            var series1 = chart2.Series[0];
            series1.LabelForeColor = Color.Black;
            var title1 = chart2.Titles[0];
            title1.ForeColor = System.Drawing.Color.Black;
            var legend2 = chart3.Legends[0];
            legend2.ForeColor = System.Drawing.Color.Black;
            var chartArea2 = chart3.ChartAreas[0];
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.Black;
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.Black;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Black;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Black;
            var series2 = chart3.Series[0];
            series2.LabelForeColor = Color.Black;
            var title2 = chart3.Titles[0];
            title2.ForeColor = System.Drawing.Color.Black;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            isDarkMode = true;
            materialButton1.BringToFront();
            ThemeManager.Instance.SetTheme(MaterialSkinManager.Themes.DARK);
            dataInventory.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataInventory.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataInventory.RowsDefaultCellStyle.ForeColor = Color.White;
            dataInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataInventory.Invalidate();

            dataStocks.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataStocks.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataStocks.RowsDefaultCellStyle.ForeColor = Color.White;
            dataStocks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataStocks.Invalidate();

            dataBrand.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataBrand.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataBrand.RowsDefaultCellStyle.ForeColor = Color.White;
            dataBrand.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataBrand.Invalidate();

            dataCategory.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataCategory.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataCategory.RowsDefaultCellStyle.ForeColor = Color.White;
            dataCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataCategory.Invalidate();

            dataSupplier.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataSupplier.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataSupplier.RowsDefaultCellStyle.ForeColor = Color.White;
            dataSupplier.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataSupplier.Invalidate();

            dataUser.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataUser.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataUser.RowsDefaultCellStyle.ForeColor = Color.White;
            dataUser.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataUser.Invalidate();

            dataStockInHistory.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataStockInHistory.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataStockInHistory.RowsDefaultCellStyle.ForeColor = Color.White;
            dataStockInHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataStockInHistory.Invalidate();

            dataAdjustment.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataAdjustment.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataAdjustment.RowsDefaultCellStyle.ForeColor = Color.White;
            dataAdjustment.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataAdjustment.Invalidate();

            dataAdjustmentHistory.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataAdjustmentHistory.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataAdjustmentHistory.RowsDefaultCellStyle.ForeColor = Color.White;
            dataAdjustmentHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataAdjustmentHistory.Invalidate();

            dataInvetoryList.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataInvetoryList.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataInvetoryList.RowsDefaultCellStyle.ForeColor = Color.White;
            dataInvetoryList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataInvetoryList.Invalidate();

            dataCriticalStocks.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataCriticalStocks.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataCriticalStocks.RowsDefaultCellStyle.ForeColor = Color.White;
            dataCriticalStocks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataCriticalStocks.Invalidate();

            dataStockInSH.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataStockInSH.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataStockInSH.RowsDefaultCellStyle.ForeColor = Color.White;
            dataStockInSH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataStockInSH.Invalidate();

            dataSalesHistory.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataSalesHistory.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataSalesHistory.RowsDefaultCellStyle.ForeColor = Color.White;
            dataSalesHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataSalesHistory.Invalidate();

            dataTopSelling.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataTopSelling.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataTopSelling.RowsDefaultCellStyle.ForeColor = Color.White;
            dataTopSelling.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataTopSelling.Invalidate();

            dataCancelled.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataCancelled.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataCancelled.RowsDefaultCellStyle.ForeColor = Color.White;
            dataCancelled.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataCancelled.Invalidate();

            dataOrders.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataOrders.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataOrders.RowsDefaultCellStyle.ForeColor = Color.White;
            dataOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataOrders.Invalidate();

            dataDeliveries.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataDeliveries.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataDeliveries.RowsDefaultCellStyle.ForeColor = Color.White;
            dataDeliveries.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataDeliveries.Invalidate();

            dataOrderHistory.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataOrderHistory.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataOrderHistory.RowsDefaultCellStyle.ForeColor = Color.White;
            dataOrderHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataOrderHistory.Invalidate();

            dataAccessLogs.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataAccessLogs.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataAccessLogs.RowsDefaultCellStyle.ForeColor = Color.White;
            dataAccessLogs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataAccessLogs.Invalidate();

            btnPrintInventoryList.BackColor = Color.White;
            btnPrintStockHistory.BackColor = Color.White;
            btnSHPrint.BackColor = Color.White;
            btnPrintTS.BackColor = Color.White;
            btnPrintCancelled.BackColor = Color.White;
            btnPrintAdjHist.BackColor = Color.White;
            btnOrderHistory.BackColor = Color.White;
            btnAccessL.BackColor = Color.White;
            var legend = chart1.Legends[0];
            legend.BackColor = Color.Transparent;
            legend.ForeColor = System.Drawing.Color.White;
            var chartArea = chart1.ChartAreas[0];
            chartArea.BackColor = Color.Transparent;
            chartArea.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            var series = chart1.Series[0];
            series.LabelForeColor = Color.White;
            var title = chart1.Titles[0];
            title.ForeColor = System.Drawing.Color.White;
            var legend1 = chart2.Legends[0];
            legend1.BackColor = Color.Transparent;
            legend1.ForeColor = System.Drawing.Color.White;
            var chartArea1 = chart2.ChartAreas[0];
            chartArea1.BackColor = Color.Transparent;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            var series1 = chart2.Series[0];
            series1.LabelForeColor = Color.White;
            var title1 = chart2.Titles[0];
            title1.ForeColor = System.Drawing.Color.White;
            var legend2 = chart3.Legends[0];
            legend2.BackColor = Color.Transparent;
            legend2.ForeColor = System.Drawing.Color.White;
            var chartArea2 = chart3.ChartAreas[0];
            chartArea2.BackColor = Color.Transparent;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            var series2 = chart3.Series[0];
            series2.LabelForeColor = Color.White;
            var title2 = chart3.Titles[0];
            title2.ForeColor = System.Drawing.Color.White;
        }


        private void dataInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataInventory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit1")
            {
                InventoryUpdate inventory = new InventoryUpdate(this);
                inventory.ProductId = dataInventory.Rows[e.RowIndex].Cells[1].Value.ToString();
                inventory.Name = dataInventory.Rows[e.RowIndex].Cells[2].Value.ToString();
                inventory.Brand = dataInventory.Rows[e.RowIndex].Cells[3].Value.ToString();
                inventory.Category = dataInventory.Rows[e.RowIndex].Cells[4].Value.ToString();
                inventory.Price = dataInventory.Rows[e.RowIndex].Cells[6].Value.ToString();
                inventory.Reorder = dataInventory.Rows[e.RowIndex].Cells[7].Value.ToString();
                inventory.IsCategoryBrand = false;

                inventory.ShowDialog();
            }
            else if (colName == "Delete1")
            {
                if (MessageBox.Show("Are you sure you want to delete this record? \n\nAll data reference related to this product will be deleted! \n(sales history)", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string productId = dataInventory.Rows[e.RowIndex].Cells["Product_Id1111"].Value.ToString();

                        using (SqlConnection cn = DatabaseManager.GetConnection())
                        {
                            cn.Open();

                            SqlTransaction transaction = cn.BeginTransaction();
                            try
                            {
                                string deleteStocksQuery = "DELETE FROM Stocks WHERE Product_Id = @ProductId";
                                using (SqlCommand cmd = new SqlCommand(deleteStocksQuery, cn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ProductId", productId);
                                    cmd.ExecuteNonQuery();
                                }

                                string cartQuery = "DELETE FROM Cart WHERE Product_Id = @ProductId";
                                using (SqlCommand cmd = new SqlCommand(cartQuery, cn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ProductId", productId);
                                    cmd.ExecuteNonQuery();
                                }

                                string deleteInventoryQuery = "DELETE FROM Inventory WHERE Product_Id = @ProductId";
                                using (SqlCommand cmd = new SqlCommand(deleteInventoryQuery, cn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ProductId", productId);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Product has been successfully deleted.", "Point Of Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No product found with the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LoadData();
                            LoadData1();
                            LoadDataStocks();
                            InventoryList();
                            CriticalStocks();
                            LoadDashboard();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            LoadData();
            LoadData();
            LoadData1();
            LoadDataStocks();
            InventoryList();
            CriticalStocks();
            LoadDashboard();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataBrand.Columns[e.ColumnIndex].Name;
            if (colName == "Edit2")
            {
                AddBrand brand = new AddBrand(this);
                brand.BrandId = dataBrand.Rows[e.RowIndex].Cells[1].Value.ToString();
                brand.Brand = dataBrand.Rows[e.RowIndex].Cells[2].Value.ToString();
                brand.Category = dataBrand.Rows[e.RowIndex].Cells[3].Value.ToString();
                brand.IsCategoryEnabled = false;

                brand.ShowDialog();
            }
            else if (colName == "Delete2")
            {
                if (MessageBox.Show("Are you sure you want to delete this record? \n\nAll data reference related to this brand will be deleted! \n(product)", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string brandId = dataBrand.Rows[e.RowIndex].Cells["Brand_Id111"].Value.ToString();

                        using (SqlConnection cn = DatabaseManager.GetConnection())
                        {
                            cn.Open();

                            SqlTransaction transaction = cn.BeginTransaction();
                            try
                            {
                                string deleteInventoryQuery = "DELETE FROM Inventory WHERE Brand_Id = @BrandId";
                                using (SqlCommand cmd = new SqlCommand(deleteInventoryQuery, cn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@BrandId", brandId);
                                    cmd.ExecuteNonQuery();
                                }

                                string deleteBrandQuery = "DELETE FROM Brand WHERE Brand_Id = @BrandId";
                                using (SqlCommand cmd = new SqlCommand(deleteBrandQuery, cn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@BrandId", brandId);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Brand has been successfully deleted.", "Point Of Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No brand found with the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LoadData();
                            LoadData1();
                            InventoryList();
                            CriticalStocks();
                            LoadDataBrand();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the brand: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            LoadData();
            LoadData1();
            InventoryList();
            CriticalStocks();
            LoadDataBrand();
        }

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            InventoryAdd inventoryAdd = new InventoryAdd();
            inventoryAdd.ShowDialog();
            //BindData();
        }

        private void materialFloatingActionButton3_Click(object sender, EventArgs e)
        {
            AddBrand brand = new AddBrand(this);
            brand.BrandAdd = false;
            brand.ShowDialog();
            //BindDataBrand();
        }

        private void materialFloatingActionButton4_Click(object sender, EventArgs e)
        {
            AddCategory category = new AddCategory(this);
            category.CategoryAdd = false;
            category.ShowDialog();
            //BindDataCategory();
        }
        private void materialFloatingActionButton5_Click(object sender, EventArgs e)
        {
            AddSupplier supplier = new AddSupplier(this);
            supplier.SupplierAdd = false;
            supplier.ShowDialog();
            //BindDataSupplier();
        }

        private void dataCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit3")
            {
                AddCategory category = new AddCategory(this);
                category.CategoryId = dataCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                category.Category = dataCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                category.IsCategoryEnabled = false;

                category.ShowDialog();
            }
            else if (colName == "Delete3")
            {
                if (MessageBox.Show("Are you sure you want to delete this record? \n\nAll data reference related to this category will be deleted! \n(brand and product)", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string categoryId = dataCategory.Rows[e.RowIndex].Cells["Category_Id1111"].Value.ToString();

                        using (SqlConnection cn = DatabaseManager.GetConnection())
                        {
                            cn.Open();

                            SqlTransaction transaction = cn.BeginTransaction();
                            try
                            {
                                string deleteInventoryQuery = "DELETE FROM Inventory WHERE Category_Id = @CategoryId";
                                using (SqlCommand cmd = new SqlCommand(deleteInventoryQuery, cn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                                    cmd.ExecuteNonQuery();
                                }
                                string deleteBrandQuery = "DELETE FROM Brand WHERE Category_Id = @CategoryId";
                                using (SqlCommand cmd = new SqlCommand(deleteBrandQuery, cn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                                    cmd.ExecuteNonQuery();
                                }

                                string deleteCategoryQuery = "DELETE FROM Category WHERE Category_Id = @CategoryId";
                                using (SqlCommand cmd = new SqlCommand(deleteCategoryQuery, cn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Category has been successfully deleted.", "Point Of Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No category found with the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        LoadDataCategory();
                        LoadDataBrand();
                        LoadData();
                        LoadData1();
                        InventoryList();
                        CriticalStocks();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the brand: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            LoadDataCategory();
            LoadDataBrand();
            LoadData();
            LoadData1();
            InventoryList();
            CriticalStocks();
        }

        private void dataSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataSupplier.Columns[e.ColumnIndex].Name;
            if (colName == "Product1")
            {
                SupplierProduct supprod = new SupplierProduct(this);
                supprod.SupplierId = dataSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
                supprod.ShowDialog();
            }
            else if (colName == "Edit4")
            {
                AddSupplier supplier = new AddSupplier(this);
                supplier.SupplierId = dataSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
                supplier.Supplier = dataSupplier.Rows[e.RowIndex].Cells[2].Value.ToString();
                supplier.Address = dataSupplier.Rows[e.RowIndex].Cells[3].Value.ToString();
                supplier.ContactPerson = dataSupplier.Rows[e.RowIndex].Cells[4].Value.ToString();
                supplier.Phone = dataSupplier.Rows[e.RowIndex].Cells[5].Value.ToString();
                supplier.Email = dataSupplier.Rows[e.RowIndex].Cells[6].Value.ToString();
                supplier.IsCategoryEnabled = false;
                supplier.ShowDialog();
            }
            else if (colName == "Delete4")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string supplierId = dataSupplier.Rows[e.RowIndex].Cells["Supplier_Id111"].Value.ToString();

                        using (SqlConnection cn = DatabaseManager.GetConnection())
                        {
                            cn.Open();

                            SqlTransaction transaction = cn.BeginTransaction();
                            try
                            {
                                string deleteSupplieryQuery = "DELETE FROM Supplier WHERE Supplier_Id = @SupplierId";
                                using (SqlCommand cmd = new SqlCommand(deleteSupplieryQuery, cn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Supplier has been successfully deleted.", "Point Of Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No supplier found with the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LoadDataSupplier();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the brand: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            LoadDataSupplier();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit5")
            {
                UpdateUser update = new UpdateUser(this);
                update.UserId = dataUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                update.Username = dataUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                update.Phone = dataUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                update.Fullname = dataUser.Rows[e.RowIndex].Cells[5].Value.ToString();
                update.Role = dataUser.Rows[e.RowIndex].Cells[6].Value.ToString();
                update.Status = dataUser.Rows[e.RowIndex].Cells[7].Value.ToString();

                update.ShowDialog();
            }
            else if(colName == "Coe")
            {

                int rowIndex = dataUser.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    string status = dataUser.Rows[rowIndex].Cells["Status"].Value.ToString();

                    if (status == "Active")
                    {
                        CertificateActive active = new CertificateActive();
                        active.EmployeeDetails(dataUser.Rows[e.RowIndex].Cells[5].Value.ToString(), dataUser.Rows[e.RowIndex].Cells[8].Value.ToString());
                        active.ShowDialog();
                    }
                    else if (status == "Resigned")
                    {
                        Certificate cert = new Certificate();
                        cert.EmployeeDetails(dataUser.Rows[e.RowIndex].Cells[5].Value.ToString(), dataUser.Rows[e.RowIndex].Cells[8].Value.ToString(), dataUser.Rows[e.RowIndex].Cells[9].Value.ToString());
                        cert.ShowDialog();
                    }
                }
            }
            else if (colName == "Delete5")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string userId = dataUser.Rows[e.RowIndex].Cells["User_Id1111"].Value.ToString();

                        using (SqlConnection cn = DatabaseManager.GetConnection())
                        {
                            cn.Open();
                            string query = "DELETE FROM [User] WHERE User_Id = @User_Id";
                            using (SqlCommand cm = new SqlCommand(query, cn))
                            {
                                cm.Parameters.AddWithValue("@User_Id", userId);

                                int rowsAffected = cm.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("User has been successfully deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No user found with the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        LoadDataUser();
                        LoadDashboard();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the brand: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            LoadDataUser();
            LoadDashboard();
        }


        private void tbNewRe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnChange.PerformClick();
            }
        }

        private void tbFull_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnCreate.PerformClick();
            }
        }

        private void dataUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dataUser.CurrentRow != null)
            {
                int i = dataUser.CurrentRow.Index;

                if (i >= 0 && i < dataUser.Rows.Count)
                {
                    string Username = dataUser[2, i].Value?.ToString();
                    string Email = dataUser[4, i].Value?.ToString();

                    if (!string.IsNullOrEmpty(Username))
                    {
                        if (lblUsername.Text == Username)
                        {
                            btnReset.Enabled = false;
                            lblnote.Text = "To change your password, go to change password tag.";
                        }
                        else
                        {
                            btnReset.Enabled = true;
                            lblnote.Text = "To change the password for " + Username + ", click Reset.";
                        }
                        lblUserReset.Text = "Password for: " + Username;
                        userreset.Text = Username;
                        useremail.Text = Email;
                    }
                    else
                    {
                        lblnote.Text = "Username not available.";
                    }
                }
                else
                {
                    lblnote.Text = "Invalid row index.";
                }
            }
            else
            {
                lblnote.Text = "No row selected.";
            }
        }


        private void lblnote_Click(object sender, EventArgs e)
        {

        }


        public void Clear()
        {
            dtStockIn.Value = DateTime.Now;
            GetRefeNo();
        }

        private void dataStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataStocks.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Remove this item?", "In Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM Stocks WHERE Stock_Id='" + dataStocks.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item has been successfully removed", "In Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataStocks();
                }
            }
        }

        //private void cbSupp_TextChanged(object sender, EventArgs e)
        //{
        //    SqlConnection cn = DatabaseManager.GetConnection();
        //    cn.Open();
        //    SqlCommand cm = new SqlCommand("SELECT * FROM Supplier WHERE Supplier LIKE '" + cbSupp.Text + "'", cn);
        //    SqlDataReader dr = cm.ExecuteReader();
        //    dr.Read();
        //    if (dr.HasRows)
        //    {
        //        lblSuppId.Text = dr["Supplier_Id"].ToString();
        //        tbContactPerson.Text = dr["Contact_Person"].ToString();
        //        tbStockInAddress.Text = dr["Address"].ToString();
        //        tbSPhone.Text = dr["Phone"].ToString();
        //    }
        //    else if (string.IsNullOrEmpty(cbSupp.Text))
        //    {
        //        lblSuppId.Text = "";
        //        tbContactPerson.Clear();
        //        tbStockInAddress.Clear();
        //        tbSPhone.Clear();
        //    }
        //    dr.Close();
        //    cn.Close();
        //}

        private void tbQty_TextChanged(object sender, EventArgs e)
        {

        }
           
        public void Noti()
        {
            int itemCount = 0;

            using (SqlConnection cn = DatabaseManager.GetConnection())
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmCritical = new SqlCommand("SELECT * FROM vwCriticalItems", cn))
                    using (SqlDataReader drCritical = cmCritical.ExecuteReader())
                    {
                        while (drCritical.Read())
                        {
                            itemCount++;
                            var alert = new AlertNotif { TopMost = true };
                            string message = $"{itemCount}. {drCritical["Name"]} - {drCritical["Quantity"]}";
                            string message1 = "WARNING!";
                            alert.showAlert(message, message1);
                        }
                    }

                    using (SqlCommand cmDelays = new SqlCommand("SELECT * FROM vwDelays", cn))
                    using (SqlDataReader drDelays = cmDelays.ExecuteReader())
                    {
                        while (drDelays.Read())
                        {
                            itemCount++;
                            var alert = new AlertNotif { TopMost = true };
                            string message = $"{itemCount}. {drDelays["SO_No"]} - {Convert.ToDateTime(drDelays["SO_Expected"]).ToString("MM/dd/yyyy")}";
                            string message1 = "DELAYED ORDER ALERT!";
                            alert.showAlert(message, message1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void InventoryList()
        {
            dataInvetoryList.Rows.Clear();
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT Name, Brand, Category, Quantity, Price, Re_Order FROM Inventory";

                using (SqlCommand cmd = new SqlCommand(selectSql, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (dr.Read())
                        {
                            i++;
                            dataInvetoryList.Rows.Add(i, dr["Name"].ToString(), dr["Brand"].ToString(),
                                                dr["Category"].ToString(), dr["Price"].ToString(),
                                                dr["Quantity"].ToString(), dr["Re_Order"].ToString());
                        }
                    }
                }
            }
        }
        public void CriticalStocks()
        {
            dataCriticalStocks.Rows.Clear();
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT Name, Brand, Category, Price, Re_Order, Quantity FROM vwCriticalItems";

                using (SqlCommand cmd = new SqlCommand(selectSql, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (dr.Read())
                        {
                            i++;
                            dataCriticalStocks.Rows.Add(i, dr["Name"].ToString(), dr["Brand"].ToString(),
                                                dr["Category"].ToString(), dr["Price"].ToString(),
                                                dr["Re_Order"].ToString(), dr["Quantity"].ToString());
                        }
                    }
                }
            }
        }

        int _qty;
        private void dataAdjustment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dataAdjustment.Columns[e.ColumnIndex].Name;

                if (colName == "Select")
                {
                    var row = dataAdjustment.Rows[e.RowIndex];
                    //lblProductDet.Text = $"{row.Cells[2].Value}  {row.Cells[3].Value}  {row.Cells[4].Value}";
                    lblProductDet.Text = $"{row.Cells[2].Value}";

                    if (int.TryParse(row.Cells[5].Value?.ToString(), out int qty))
                    {
                        _qty = qty;
                        btnSaveSA.Enabled = true;
                    }
                    else
                    {
                        _qty = 0;
                        btnSaveSA.Enabled = false;
                    }

                    lblprodId.Text = row.Cells["Product_IdSAA"].Value?.ToString() ?? string.Empty;
                }
            }
        }
        public void ReferenceNo()//Adjust Stock
        {
            /*Random rdm = new Random();
            lblRefNo.Text = rdm.Next().ToString();*/

            // Get the current date in the format of yyyyMMdd (year, month, day)
            string datePart = DateTime.Now.ToString("yyyyMMdd");

            // Generate a random 4-digit number
            Random random = new Random();
            int randomDigits = random.Next(0000, 9999);

            // Combine the date and the random number
            string randomNumber = $"{datePart}{randomDigits}";

            // Display the result (e.g., in a label or textbox)
            lblRefNo.Text = randomNumber;


        }

        public void GetRefeNo()//In Stock
        {

            /*Random rnd = new Random();
            lblReference.Text = rnd.Next(1000, 8999).ToString();*/

            // Get the current date in the format of yyyyMMdd (year, month, day)
            string datePart = DateTime.Now.ToString("yyyyMMdd");

            // Generate a random 4-digit number
            Random randomizer = new Random();
            int randomDigits = randomizer.Next(1000, 9999);

            // Combine the date and the random number
            string randomNumber1 = $"{datePart}{randomDigits}";

            // Display the result (e.g., in a label or textbox)
            lblReference.Text = randomNumber1;

        }
        public void RefNo()//In Stock
        {

            /*Random rnd = new Random();
            lblReference.Text = rnd.Next(1000, 8999).ToString();*/

            // Get the current date in the format of yyyyMMdd (year, month, day)
            string datePart = DateTime.Now.ToString("yyyyMMdd");

            // Generate a random 4-digit number
            Random randomizer = new Random();
            int randomDigits = randomizer.Next(1000, 9999);

            // Combine the date and the random number
            string randomNumber2 = $"{datePart}{randomDigits}";

            // Display the result (e.g., in a label or textbox)
            lblNo.Text = randomNumber2;

        }
        public void Clear1()//Adjust Stock
        {
            lblProductDet.Text = "";
            tbQty.Clear();
            tbRemarks.Clear();
            cbAction.Text = "";
            ReferenceNo();
        }

        private void ShowWarning(string message, Control focusControl = null)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focusControl?.Focus();
        }

        private void btnPrintInventoryList_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            rep.LoadInventory("SELECT * FROM vwInventoryList");
            rep.ShowDialog();
        }

        private void btnPrintStockHistory_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            string param = "From : " + dtFromSH.Value.ToString("yyyy-MM-dd") + " To : " + DttoSH.Value.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM vwStockInHistory WHERE StockInDate BETWEEN @FromDate AND @ToDate AND Status LIKE 'Done'";
            rep.LoadStockInHistory(sql, param, dtFromSH.Value, DttoSH.Value);
            rep.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }


        private void btnSHPrint_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            string param = "From : " + dtSHFrom.Value.ToString("yyyy-MM-dd") + " To : " + dtSHto.Value.ToString("yyyy-MM-dd");
            string query = "SELECT Cart_Id, TransactionNo, Name, Price, Quantity, Discount, Total FROM vwCart WHERE Status = 'Sold' AND Date BETWEEN @startDate AND @endDate";
            rep.LoadSalesHistory(query, param, dtSHFrom.Value.Date, dtSHto.Value.Date);
            rep.ShowDialog();
        }


        public void LoadTopSelling()
        {
            int i = 0;
            dataTopSelling.Rows.Clear();
            
            try
            {
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();

                    string query = string.Empty;
                    if (cbTopS.Text == "Sort By Quantity")
                    {
                        query = @"SELECT TOP 10 Name, ISNULL(SUM(Quantity), 0) AS Quantity, ISNULL(SUM(Total), 0) AS Total, Product_Id FROM vwCart WHERE Date BETWEEN @DateFrom AND @DateTo AND Status = 'Sold' GROUP BY Product_Id, Name ORDER BY Quantity DESC";
                    }
                    else if (cbTopS.Text == "Sort By Total Sales")
                    {
                        query = @"SELECT TOP 10 Name, ISNULL(SUM(Quantity), 0) AS Quantity, ISNULL(SUM(Total), 0) AS Total, Product_Id FROM vwCart WHERE Date BETWEEN @DateFrom AND @DateTo AND Status = 'Sold' GROUP BY Product_Id, Name ORDER BY Total DESC";
                    }

                    using (SqlCommand cm = new SqlCommand(query, cn))
                    {
                        cm.Parameters.AddWithValue("@DateFrom", dtTSFrom.Value.Date);
                        cm.Parameters.AddWithValue("@DateTo", dtTSto.Value.Date);

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                i++;
                                dataTopSelling.Rows.Add(
                                    i,
                                    dr["Name"].ToString(),
                                    dr["Quantity"].ToString(),
                                    int.Parse(dr["Total"].ToString()).ToString("###,###,##0"),
                                    dr["Product_Id"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnPrintTS_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            string param = "From : " + dtTSFrom.Value.ToString("yyyy-MM-dd") + " To : " + dtTSto.Value.ToString("yyyy-MM-dd");

            string query = string.Empty;
            if (cbTopS.Text == "Sort By Quantity")
            {
                query = @"SELECT TOP 10 Product_Id, Name, ISNULL(SUM(Quantity), 0) AS Quantity, ISNULL(SUM(Total), 0) AS Total
                  FROM vwTopSelling 
                  WHERE Date BETWEEN @DateFrom AND @DateTo AND Status = 'Sold' 
                  GROUP BY Product_Id, Name 
                  ORDER BY Quantity DESC";
            }
            else if (cbTopS.Text == "Sort By Total Sales")
            {
                query = @"SELECT TOP 10 Product_Id, Name, ISNULL(SUM(Quantity), 0) AS Quantity, ISNULL(SUM(Total), 0) AS Total
                  FROM vwTopSelling 
                  WHERE Date BETWEEN @DateFrom AND @DateTo AND Status = 'Sold' 
                  GROUP BY Product_Id, Name 
                  ORDER BY Total DESC";
            }

            DateTime dateFrom = dtTSFrom.Value.Date;
            DateTime dateTo = dtTSto.Value.Date;

            report.LoadTopSelling(query, dateFrom, dateTo, param, "TOP SELLING ITEMS " + (cbTopS.Text == "Sort By Quantity" ? "SORT BY QUANTITY" : "SORT BY TOTAL SALES"));
            report.ShowDialog();
        }

        private void btnSbrowse_Click(object sender, EventArgs e)
        {
            ProductStockIn productStock = new ProductStockIn(this);
            productStock.ShowDialog();
        }

        private void btnSEntry_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataStocks.Rows.Count; i++)
                {
                    if (int.Parse(dataStocks.Rows[i].Cells[4].Value.ToString()) == 0)
                    {
                        MessageBox.Show("Please Input Some Quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                if (dataStocks.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to save this records?", "In Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataStocks.Rows.Count; i++)
                        {
                            cn.Open();
                            cm = new SqlCommand("UPDATE Inventory SET Quantity = Quantity + " + int.Parse(dataStocks.Rows[i].Cells[4].Value.ToString()) + " WHERE Product_Id LIKE '" + dataStocks.Rows[i].Cells[8].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();

                            cn.Open();
                            cm = new SqlCommand("UPDATE Stocks SET Quantity = Quantity + " + int.Parse(dataStocks.Rows[i].Cells[4].Value.ToString()) + ", Status='Done' WHERE Stock_Id LIKE '" + dataStocks.Rows[i].Cells[1].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }
                        Clear();
                        LoadDataStocks();
                        LoadData();
                        LoadData1();
                        InventoryList();
                        CriticalStocks();
                        LoadDashboard();
                        dataStocks.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "In Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvClear_Click(object sender, EventArgs e)
        {
            dataStockInHistory.Rows.Clear();
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
        }

        private void btnSLoad_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataStockInHistory.Rows.Clear();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    string selectSql = @"
                        SELECT s.Stock_Id, s.Reference, i.Name, s.Quantity, s.StockInDate, s.StockInBy, s.Product_Id
                        FROM Stocks s 
                        INNER JOIN Inventory i ON s.Product_Id = i.Product_Id
                        WHERE s.Status = 'Done' AND s.StockInDate BETWEEN @FromDate AND @ToDate";

                    using (SqlCommand cm = new SqlCommand(selectSql, cn))
                    {
                        cm.Parameters.AddWithValue("@FromDate", dtFrom.Value.Date);
                        cm.Parameters.AddWithValue("@ToDate", dtTo.Value.Date);

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                i++;
                                dataStockInHistory.Rows.Add(
                                    i,
                                    dr["Reference"].ToString(),
                                    dr["Name"].ToString(),
                                    dr["Quantity"].ToString(),
                                    dr["StockInDate"] != DBNull.Value ? ((DateTime)dr["StockInDate"]).ToShortDateString() : string.Empty,
                                    dr["StockInBy"].ToString(),
                                    dr["Product_Id"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveSA_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cbAction.Text))
                {
                    ShowWarning("Please select an action for add or reduce.", cbAction);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbQty.Text))
                {
                    ShowWarning("Please input quantity for add or reduce.", tbQty);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbRemarks.Text))
                {
                    ShowWarning("Need reason for stock adjustment.", tbRemarks);
                    return;
                }

                if (!int.TryParse(tbQty.Text, out int qty))
                {
                    ShowWarning("Invalid quantity format.", tbQty);
                    return;
                }

                if (qty > _qty)
                {
                    ShowWarning("Stock on hand quantity should be greater than adjustment quantity.");
                    return;
                }

                string productId = lblprodId.Text;

                if (string.IsNullOrEmpty(productId))
                {
                    ShowWarning("No product selected.");
                    return;
                }

                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();

                    string updateQuery = cbAction.Text == "Remove From Inventory"
                        ? "UPDATE Inventory SET Quantity = Quantity - @Qty WHERE Product_Id = @ProductId"
                        : "UPDATE Inventory SET Quantity = Quantity + @Qty WHERE Product_Id = @ProductId";

                    using (SqlCommand cm = new SqlCommand(updateQuery, cn))
                    {
                        cm.Parameters.AddWithValue("@Qty", qty);
                        cm.Parameters.AddWithValue("@ProductId", productId);
                        cm.ExecuteNonQuery();
                    }


                    string insertQuery = "INSERT INTO Adjust (Reference, Quantity, Action, Remarks, Date, [User]) VALUES (@Reference, @Quantity, @Action, @Remarks, @Date, @User)";

                    using (SqlCommand cm = new SqlCommand(insertQuery, cn))
                    {
                        cm.Parameters.AddWithValue("@Reference", lblRefNo.Text);
                        cm.Parameters.AddWithValue("@Quantity", qty);
                        cm.Parameters.AddWithValue("@Action", cbAction.Text);
                        cm.Parameters.AddWithValue("@Remarks", tbRemarks.Text);
                        cm.Parameters.AddWithValue("@Date", DateTime.Now);
                        cm.Parameters.AddWithValue("@User", lblUserSA.Text);
                        cm.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Stock has been successfully adjusted.", "Process completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LoadData1();
                LoadDataStocks();
                InventoryList();
                CriticalStocks();
                LoadDashboard();
                dataStocks.DataSource = null;
                Clear1();
                btnSaveSA.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbUser.Text) || string.IsNullOrWhiteSpace(tbPhone.Text) ||
                    string.IsNullOrWhiteSpace(tbAddress.Text) || string.IsNullOrWhiteSpace(tbEmail.Text) ||
                    string.IsNullOrWhiteSpace(tbPass.Text) || string.IsNullOrWhiteSpace(tbRePass.Text) ||
                    string.IsNullOrWhiteSpace(tbFull.Text))
                {
                    MessageBox.Show("Please Fill Out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cbGender.Text))
                {
                    MessageBox.Show("Please Select Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cbRole.Text))
                {
                    MessageBox.Show("Please Select Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tbPass.Text != tbRePass.Text)
                {
                    MessageBox.Show("Your password does not match!", "ERROR", MessageBoxButtons.OK);
                    return;
                }

                if (!IsValidEmail(tbEmail.Text))
                {
                    MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    SqlCommand checkUsername = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @Username", conn);
                    checkUsername.Parameters.AddWithValue("@Username", tbUser.Text);
                    int userExists = (int)checkUsername.ExecuteScalar();

                    if (userExists > 0)
                    {
                        MessageBox.Show("Username already exists! Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlCommand checkemail = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Email = @Email", conn);
                    checkemail.Parameters.AddWithValue("@Email", tbEmail.Text);
                    int emailExists = (int)checkemail.ExecuteScalar();

                    if (emailExists > 0)
                    {
                        MessageBox.Show("Email already exists! Please choose a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string encryptedPassword = EncryptionHelper.Encrypt(tbPass.Text);

                    DateTime date = DateTime.Now;
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO [User] (Username, Address, Phone, Email, BirthDate, Gender, Password, Role, FullName, Date) VALUES (@Username, @Address, @Phone, @Email, @BirthDate, @Gender, @Password, @Role, @FullName, @Date)", conn);
                    insertCommand.Parameters.AddWithValue("@Username", tbUser.Text);
                    insertCommand.Parameters.AddWithValue("@Address", tbAddress.Text);
                    insertCommand.Parameters.AddWithValue("@Phone", tbPhone.Text);
                    insertCommand.Parameters.AddWithValue("@Email", tbEmail.Text);
                    insertCommand.Parameters.AddWithValue("@BirthDate", Convert.ToDateTime(dtBirth.Text));
                    insertCommand.Parameters.AddWithValue("@Gender", cbGender.Text);
                    insertCommand.Parameters.AddWithValue("@Password", encryptedPassword);
                    insertCommand.Parameters.AddWithValue("@Role", cbRole.Text);
                    insertCommand.Parameters.AddWithValue("@FullName", tbFull.Text);
                    insertCommand.Parameters.AddWithValue("@Date", date);
                    insertCommand.ExecuteNonQuery();

                    MessageBox.Show("Create Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbUser.Clear();
                    tbAddress.Clear();
                    tbPhone.Clear();
                    tbEmail.Clear();
                    cbGender.Text = "";
                    cbRole.Text = "";
                    tbPass.Clear();
                    tbRePass.Clear();
                    tbFull.Clear();
                }

                LoadDataUser();
                LoadDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK);
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern);
            }
            catch
            {
                return false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string decryptedPassword = EncryptionHelper.Decrypt(_pass);

            if (tbCurrent.Text != decryptedPassword)
            {
                MessageBox.Show("Current password did not match!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (tbNew.Text != tbNewRe.Text)
            {
                MessageBox.Show("Confirm new password did not match!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(tbNew.Text))
            {
                MessageBox.Show("Please Input!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(tbNewRe.Text))
            {
                MessageBox.Show("Please Input!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE [User] SET Password = @NewPassword WHERE Username = @Username";

                    string encryptedPassword = EncryptionHelper.Encrypt(tbNew.Text);
                    

                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@NewPassword", encryptedPassword);
                        comm.Parameters.AddWithValue("@Username", lblUser1.Text);

                        int rowsAffected = comm.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password has been successfully changed! \n\nIf you want to change password again, you need to logout first then login again.", "Changed Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbCurrent.Clear();
                            tbNew.Clear();
                            tbNewRe.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Password change failed. User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset reset = new Reset();
            reset.labelReset = userreset.Text;
            reset.labelEmail = useremail.Text;
            reset.ShowDialog();
        }

        private void btnLoadTS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbTopS.Text))
            {
                MessageBox.Show("Please select sort type from the dropdown list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTopS.Focus();
                return;
            }
            LoadTopSelling();
            //LoadChartTopSelling();
        }
        //public void LoadChartTopSelling()
        //{
        //    using (SqlConnection cn = DatabaseManager.GetConnection())
        //    {
        //        cn.Open();

        //        string query = string.Empty;

        //        if (cbTopS.Text == "Sort By Quantity")
        //        {
        //            query = "SELECT TOP 10 Name, ISNULL(SUM(Quantity), 0) AS Quantity " +
        //                    "FROM vwCart " +
        //                    "WHERE Date BETWEEN @FromDate AND @ToDate AND Status = 'Sold' " +
        //                    "GROUP BY Name ORDER BY Quantity DESC";
        //        }
        //        else if (cbTopS.Text == "Sort By Total Sales")
        //        {
        //            query = "SELECT TOP 10 Name, ISNULL(SUM(Total), 0) AS Total " +
        //                    "FROM vwCart " +
        //                    "WHERE Date BETWEEN @FromDate AND @ToDate AND Status = 'Sold' " +
        //                    "GROUP BY Name ORDER BY Total DESC";
        //        }

        //        using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
        //        {
        //            da.SelectCommand.Parameters.AddWithValue("@FromDate", dtTSFrom.Value.Date);
        //            da.SelectCommand.Parameters.AddWithValue("@ToDate", dtTSto.Value.Date);

        //            DataSet ds = new DataSet();
        //            da.Fill(ds, "TOPSELLING");

        //            chart4.Series.Clear();

        //            Series series = new Series
        //            {
        //                Name = "TOP SELLING",
        //                ChartType = SeriesChartType.Pie,
        //                IsValueShownAsLabel = true
        //            };

        //            chart4.Series.Add(series); 

        //            chart4.DataSource = ds.Tables["TOPSELLING"];
        //            series.XValueMember = "Name";

        //            if (cbTopS.Text == "Sort By Quantity")
        //            {
        //                series.YValueMembers = "Quantity";
        //                series.LabelFormat = "{###,###,##0}";
        //            }
        //            else if (cbTopS.Text == "Sort By Total Sales")
        //            {
        //                series.YValueMembers = "Total";
        //                series.LabelFormat = "{###,###,##0}";
        //            }

        //            chart4.Legends.Clear(); 
        //            Legend legend = new Legend
        //            {
        //                Docking = Docking.Right,
        //                Alignment = StringAlignment.Center,
        //                BackColor = Color.Transparent
        //            };
        //            chart4.Legends.Add(legend); 
        //        }
        //    }
        //}

        private void btnClearTS_Click(object sender, EventArgs e)
        {
            dataTopSelling.Rows.Clear();
            dtTSFrom.Value = DateTime.Now;
            dtTSto.Value = DateTime.Now;
        }

        private void btnLoadSH_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataStockInSH.Rows.Clear();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    string selectSql = @"
                SELECT s.Stock_Id, s.Reference, i.Name, s.Quantity, s.StockInDate, s.StockInBy, s.Status, s.Product_Id
                FROM Stocks s 
                INNER JOIN Inventory i ON s.Product_Id = i.Product_Id
                WHERE s.Status = 'Done' AND s.StockInDate BETWEEN @FromDate AND @ToDate";

                    using (SqlCommand cm = new SqlCommand(selectSql, cn))
                    {
                        cm.Parameters.AddWithValue("@FromDate", dtFromSH.Value.Date);
                        cm.Parameters.AddWithValue("@ToDate", DttoSH.Value.Date);

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                i++;
                                dataStockInSH.Rows.Add(
                                    i,
                                    dr["Stock_Id"].ToString(),
                                    dr["Reference"].ToString(),
                                    dr["Name"].ToString(),
                                    dr["Quantity"].ToString(),
                                    dr["StockInDate"] != DBNull.Value ? ((DateTime)dr["StockInDate"]).ToShortDateString() : string.Empty,
                                    dr["StockInBy"].ToString(),
                                    dr["Status"].ToString(),
                                    dr["Product_Id"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSH_Click(object sender, EventArgs e)
        {
            dataStockInSH.Rows.Clear();
            dtFromSH.Value = DateTime.Now;
            DttoSH.Value = DateTime.Now;
        }

        private void btnSalesH_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            int totalAmount = 0;
            dataSalesHistory.Rows.Clear();

            string query = @"SELECT c.Cart_Id, c.TransactionNo, p.Name, c.Price, c.Quantity, c.Discount, c.Total, c.Product_Id, c.Cashier, c.Date FROM Cart c INNER JOIN Inventory p ON c.Product_Id = p.Product_Id WHERE c.Status = 'Sold' AND c.Date BETWEEN @startDate AND @endDate";

            using (SqlConnection cn = DatabaseManager.GetConnection())
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", dtSHFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@endDate", dtSHto.Value.Date);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rowIndex++;
                                totalAmount += reader.GetInt32(reader.GetOrdinal("Total"));
                                dataSalesHistory.Rows.Add(
                                    rowIndex,
                                    reader["Cart_Id"].ToString(),
                                    reader["TransactionNo"].ToString(),
                                    reader["Name"].ToString(),
                                    reader["Price"].ToString(),
                                    reader["Quantity"].ToString(),
                                    reader["Discount"].ToString(),
                                    reader["Total"].ToString(),
                                    reader["Product_Id"].ToString(),
                                    reader["Cashier"].ToString(),
                                    ((DateTime)reader["Date"]).ToShortDateString()
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            lblSHTotal.Text = totalAmount.ToString("###,###,##0");
        }

        private void btnSHClear_Click(object sender, EventArgs e)
        {
            dataSalesHistory.Rows.Clear();
            dtSHFrom.Value = DateTime.Now;
            dtSHto.Value = DateTime.Now;
            lblSHTotal.Text = "0";
        }

        private void btnLoadAR_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataAdjustmentHistory.Rows.Clear();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    string selectSql = @"SELECT * FROM Adjust WHERE Date BETWEEN @FromDate AND @ToDate";

                    using (SqlCommand cm = new SqlCommand(selectSql, cn))
                    {
                        DateTime toDate = DttoAR.Value.Date.AddDays(1).AddTicks(-1);

                        cm.Parameters.AddWithValue("@FromDate", dtFromAR.Value.Date);
                        cm.Parameters.AddWithValue("@ToDate", toDate);

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                i++;
                                dataAdjustmentHistory.Rows.Add(
                                    i,
                                    dr["Reference"].ToString(),
                                    dr["Action"].ToString(),
                                    dr["Quantity"].ToString(),
                                    dr["Remarks"].ToString(),
                                    dr["Date"] != DBNull.Value ? ((DateTime)dr["Date"]).ToShortDateString() : string.Empty,
                                    dr["User"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClearAR_Click(object sender, EventArgs e)
        {
            dataAdjustmentHistory.Rows.Clear();
            dtFromAR.Value = DateTime.Now;
            DttoAR.Value = DateTime.Now;
        }

        private void btnCLoad_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataCancelled.Rows.Clear();

                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand("SELECT * FROM Cancel WHERE Date BETWEEN @DateFrom AND @DateTo", cn))
                    {
                        cm.Parameters.AddWithValue("@DateFrom", dtCFrom.Value.Date);
                        cm.Parameters.AddWithValue("@DateTo", dtCTo.Value.Date);

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                i++;
                                dataCancelled.Rows.Add(
                                    i,
                                    dr["Cancel_Id"].ToString(),
                                    dr["TransactionNo"].ToString(),
                                    dr["Price"].ToString(),
                                    dr["Quantity"].ToString(),
                                    dr["Total"].ToString(),
                                    dr["Date"] != DBNull.Value ? ((DateTime)dr["Date"]).ToShortDateString() : string.Empty,
                                    dr["VoidBy"].ToString(),
                                    dr["CancelledBy"].ToString(),
                                    dr["Reason"].ToString(),
                                    dr["Action"].ToString()
                                );
                            }
                        }
                    }
                }     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCClear_Click(object sender, EventArgs e)
        {
            dataCancelled.Rows.Clear();
            dtCFrom.Value = DateTime.Now;
            dtCTo.Value = DateTime.Now;
        }

        private void btnPrintCancelled_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            string param = "From : " + dtCFrom.Value.ToString("yyyy-MM-dd") + " To : " + dtCTo.Value.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM Cancel WHERE Date BETWEEN @FromDate AND @ToDate";
            rep.LoadCancelledOrder(sql, param, dtCFrom.Value.Date, dtCTo.Value.Date);
            rep.ShowDialog();
        }

        private void btnPrintAdjHist_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            string param = "From : " + dtFromAR.Value.ToString("yyyy-MM-dd") + " To : " + DttoAR.Value.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM Adjust WHERE Date BETWEEN @startDate AND @endDate";
            rep.LoadAdjustmentHistory(sql, param, dtFromAR.Value.Date, DttoAR.Value.Date);
            rep.ShowDialog();
        }

        private void dataInventory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dataInventory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                dataInventory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataBrand_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataBrand.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataBrand.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataCategory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataCategory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataCategory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataStocks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataStocks.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataStocks.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataStockInHistory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataStockInHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataStockInHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataAdjustment_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataAdjustment.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataAdjustment.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataSupplier_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataSupplier.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataSupplier.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }
        private void dataUser_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataUser.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataUser.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataInvetoryList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataInvetoryList.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataInvetoryList.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataTopSelling_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataTopSelling.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataTopSelling.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataStockInSH_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataStockInSH.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataStockInSH.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataSalesHistory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataSalesHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataSalesHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataCriticalStocks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataCriticalStocks.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataCriticalStocks.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataAdjustmentHistory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataAdjustmentHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataAdjustmentHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataCancelled_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataCancelled.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataCancelled.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        public void LoadCategory()
        {
            string query = "SELECT * FROM Category";
            try
            {
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            DataRow emptyRow = dataTable.NewRow();
                            emptyRow["Category"] = "";
                            dataTable.Rows.InsertAt(emptyRow, 0);

                            cbSelectC.DataSource = dataTable;
                            cbSelectC.DisplayMember = "Category";
                            cbSelectC.ValueMember = "Category";
                            cbSelectC.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void cbSelectC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cbSelectC.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                string query = "SELECT b.Brand_Id, b.Brand, b.Category_Id, c.Category FROM Brand b INNER JOIN Category c ON b.Category_Id = c.Category_Id WHERE c.Category = @SelectedCategory";

                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SelectedCategory", selectedCategory);
                        conn.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataBrand.DataSource = dataTable;
                        }
                    }
                }
            }
            else
            {
                LoadDataBrand();
            }
        }
       
        public void LoadDeliveries()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = @"
                            WITH RankedOrders AS (
                                SELECT 
                                    SO_Id, 
                                    SO_No, 
                                    SO_Supplier, 
                                    SO_Created, 
                                    SO_Expected, 
                                    SO_Status,
                                    ROW_NUMBER() OVER (PARTITION BY SO_No ORDER BY SO_Created) AS rn
                                FROM SuppliersOrder
                                WHERE SO_Status = 'On The Way'
                            )
                            SELECT SO_Id, SO_No, SO_Supplier, SO_Created, SO_Expected, SO_Status
                            FROM RankedOrders
                            WHERE rn = 1";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataDeliveries.DataSource = dataTable;
                    dataDeliveries.ClearSelection();
                    dataDeliveries.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void btnAOrder_Click(object sender, EventArgs e)
        {
            if (cbAOSupp.Text == string.Empty)
            {
                MessageBox.Show("Please Select!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = 0; i < dataOrders.Rows.Count; i++)
            {
                if (int.Parse(dataOrders.Rows[i].Cells[5].Value.ToString()) == 0)
                {
                    MessageBox.Show("Please Input Some Quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return; 
                }
            }

            if (MessageBox.Show("Are you sure you want to submit this records?", "Supplier's Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    string sql = "UPDATE SuppliersOrder SET SO_Quantity = @Quantity, SO_Status = 'On The Way', SO_Expected = @Expected WHERE SO_Id = @SO_Id";
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        for (int i = 0; i < dataOrders.Rows.Count; i++)
                        {
                            comm.Parameters.Clear();
                            comm.Parameters.AddWithValue("@Quantity", int.Parse(dataOrders.Rows[i].Cells[5].Value.ToString()));
                            comm.Parameters.AddWithValue("@Expected", dtED.Value.Date);
                            comm.Parameters.AddWithValue("@SO_Id", int.Parse(dataOrders.Rows[i].Cells[1].Value.ToString()));
                            comm.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Order has been successfully submitted!", "Supplier's Order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDeliveries();
                    dataOrders.DataSource = null;
                    Clear2();
                }
            }
        }

        public void Clear2()
        {
            dtED.Value = DateTime.Now;
            RefNo();
            cbAOSupp.Enabled = true;
        }
        public void LoadCSupplier()
        {
            string query = "SELECT * FROM Supplier";
            try
            {
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            DataRow emptyRow = dataTable.NewRow();
                            emptyRow["Supplier"] = "";
                            dataTable.Rows.InsertAt(emptyRow, 0);

                            cbDSupp.DataSource = dataTable;
                            cbDSupp.DisplayMember = "Supplier";
                            cbDSupp.ValueMember = "Supplier";
                            cbDSupp.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        //public void LoadAOSupplier()
        //{
        //    string query = "SELECT * FROM Supplier";
        //    try
        //    {
        //        using (SqlConnection cn = DatabaseManager.GetConnection())
        //        {
        //            cn.Open();
        //            using (SqlCommand cmd = new SqlCommand(query, cn))
        //            {
        //                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //                {
        //                    DataTable dataTable = new DataTable();
        //                    adapter.Fill(dataTable);

        //                    DataRow emptyRow = dataTable.NewRow();
        //                    emptyRow["Supplier"] = "";
        //                    dataTable.Rows.InsertAt(emptyRow, 0);

        //                    cbAOSupp.DataSource = dataTable;
        //                    cbAOSupp.DisplayMember = "Supplier";
        //                    cbAOSupp.SelectedIndex = 0;

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //}
        public void LoadProducts()
        {
            string selectSql = @"SELECT * FROM SuppliersOrder WHERE SO_No LIKE @No AND SO_Status = 'Pending'";
            try
            {
                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(selectSql, conn);
                    cmd.Parameters.AddWithValue("@No", "%" + lblNo.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataOrders.DataSource = dt;
                    dataOrders.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbDSupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSupplier = cbDSupp.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(selectedSupplier))
            {
                string query = @"
                            WITH RankedOrders AS (
                                SELECT 
                                    SO_Id, 
                                    SO_No, 
                                    SO_Supplier, 
                                    SO_Created, 
                                    SO_Expected, 
                                    SO_Status,
                                    ROW_NUMBER() OVER (PARTITION BY SO_No ORDER BY SO_Created) AS rn
                                FROM SuppliersOrder
                                WHERE SO_Status = 'On The Way'
                            )
                            SELECT SO_Id, SO_No, SO_Supplier, SO_Created, SO_Expected, SO_Status
                            FROM RankedOrders
                            WHERE rn = 1 AND SO_Supplier = @SelectedSupplier";

                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SelectedSupplier", selectedSupplier);
                        conn.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataDeliveries.DataSource = dataTable;
                        }
                    }
                }
            }
            else
            {
                LoadDeliveries();
            }
        }

        List<Supplier> supplier = new List<Supplier>();

        public void LoadProduct()
        {
            cbAOSupp.Items.Clear();

            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();

                using (SqlCommand comm = new SqlCommand("SELECT * FROM Supplier", conn))
                using (SqlDataReader dr = comm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cbAOSupp.Items.Add(dr["Supplier"]);
                        supplier.Add(new Supplier()
                        {
                            Supplier_Id = ((int)dr["Supplier_Id"]),
                            SupplierName = dr["Supplier"] as string

                        });
                    }
                }
            }
        }
        [Serializable]
        class Supplier
        {
            public int Supplier_Id { get; set; }
            public string SupplierName { get; set; }
        }

        string sid;
        private void cbAOSupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = supplier[cbAOSupp.SelectedIndex].Supplier_Id;

            SqlConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            string q = "SELECT Supplier_Id FROM Supplier WHERE Supplier = '" + cbAOSupp.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sid = dr[0].ToString();             
            }
            conn.Close();
            lblSupId.Text = sid;
        }
        private void LoadOrderProduct()
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string selectSql = "SELECT * FROM SuppliersOrder WHERE SO_Status = 'Pending'";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataOrders.DataSource = dataTable;
                    dataOrders.Columns["NumberColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private void btnADAdd_Click(object sender, EventArgs e)
        {
            if(cbAOSupp.Text == string.Empty)
            {
                MessageBox.Show("Please select Supplier First!", "Supplier's Product", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                string supIdText = lblSupId.Text;
                AddProduct aprod = new AddProduct(this, supIdText);
                cbAOSupp.Enabled = false;
                aprod.ShowDialog();
            }           
        }


        private void tbAOQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnADAdd.PerformClick();
            }
        }

        private void dataDeliveries_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataDeliveries.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataDeliveries.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void dataOrders_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        

        private void dataDeliveries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataDeliveries.Columns[e.ColumnIndex].Name;
            if (colName == "List1")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataDeliveries.Rows[e.RowIndex];

                    string referenceNo = selectedRow.Cells["SO_No"].Value.ToString();

                    SupplierList slit = new SupplierList(this, referenceNo);
                    slit.ShowDialog();
                }
                //SupplierList suplist = new SupplierList(this, referenceNo);
                //suplist.RefNo = dataDeliveries.Rows[e.RowIndex].Cells[4].Value.ToString();
                //suplist.ShowDialog();
            }
            else if (colName == "Edit6")
            {
                EditOrders edorder = new EditOrders(this);

                edorder.SOStatus = dataDeliveries.Rows[e.RowIndex].Cells[8].Value.ToString();
                edorder.SONo = dataDeliveries.Rows[e.RowIndex].Cells[4].Value.ToString();
                edorder.SORb = lblUserSA.Text;
                edorder.ShowDialog();
            }
        }

        private void dataDeliveries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataDeliveries.Rows[e.RowIndex];

                string referenceNo = selectedRow.Cells["SO_No"].Value.ToString();

                SupplierList slit = new SupplierList(this, referenceNo);
                slit.Show();
            }
        }

        private void dataOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataOrders.Columns[e.ColumnIndex].Name;

            if (colName == "Delete6")
            {
                if (MessageBox.Show("Remove this item?", "Supplier's Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM SuppliersOrder WHERE SO_Id='" + dataOrders.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item has been successfully removed", "Supplier's Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();

                    if (dataOrders.Rows.Count == 0)
                    {
                        cbAOSupp.Enabled = true;
                    }
                    else
                    {
                        cbAOSupp.Enabled = false;
                    }
                }
            }
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            string param = "From : " + dtFromOH.Value.ToString("yyyy-MM-dd") + " To : " + dtToOH.Value.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM vwOrder WHERE SO_Created BETWEEN @FromDate AND @ToDate AND SO_Status = 'Delivered'";
            rep.LoadOrders(sql, param, dtFromOH.Value.Date, dtToOH.Value.Date);
            rep.ShowDialog();
        }

        private void btnOHLoad_Click(object sender, EventArgs e)
        {
            int totalAmount = 0;
            try
            {
                int i = 0;              
                dataOrderHistory.Rows.Clear();

                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand("SELECT * FROM vwOrder WHERE SO_Created BETWEEN @DateFrom AND @DateTo AND  (SO_Status = 'Delivered' OR SO_Status = 'Cancelled')", cn))
                    {
                        cm.Parameters.AddWithValue("@DateFrom", dtFromOH.Value.Date);
                        cm.Parameters.AddWithValue("@DateTo", dtToOH.Value.Date);

                        using (SqlDataReader reader = cm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                i++;
                                totalAmount += reader.GetInt32(reader.GetOrdinal("SO_Total"));
                                dataOrderHistory.Rows.Add(
                                    i,
                                    reader["So_Id"].ToString(),
                                    reader["SO_No"].ToString(),
                                    reader["SO_Product"].ToString(),
                                    reader["SO_Price"].ToString(),
                                    reader["SO_Quantity"].ToString(),                                   
                                    reader["SO_Total"].ToString(),
                                    reader["SO_Created"] != DBNull.Value ? ((DateTime)reader["SO_Created"]).ToShortDateString() : string.Empty,
                                    reader["SO_Received"] != DBNull.Value ? ((DateTime)reader["SO_Received"]).ToShortDateString() : string.Empty,
                                    reader["SO_Supplier"].ToString(),
                                    reader["SO_Status"].ToString(),
                                    reader["SO_OrderBy"].ToString(),
                                    reader["SO_ReceivedBy"].ToString(),
                                    reader["SO_Expected"].ToString(),
                                    reader["Supplier_Id"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblOHTotal.Text = totalAmount.ToString("###,###,##0");
        }

        private void btnOHClear_Click(object sender, EventArgs e)
        {
            dataOrderHistory.Rows.Clear();
            dtFromOH.Value = DateTime.Now;
            dtToOH.Value = DateTime.Now;
            lblOHTotal.Text = "0";
        }

        private void dataOrderHistory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataOrderHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataOrderHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void btnAccessL_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataAccessLogs.Rows.Clear();

                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand("SELECT * FROM AccessLogs WHERE Date BETWEEN @DateFrom AND @DateTo", cn))
                    {
                        cm.Parameters.AddWithValue("@DateFrom", dtALFrom.Value.Date);
                        cm.Parameters.AddWithValue("@DateTo", dtALto.Value.Date);

                        using (SqlDataReader reader = cm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                i++;
                                string timeIn = reader["TimeIn"] != DBNull.Value ? ConvertTo12HourFormat((TimeSpan)reader["TimeIn"]) : string.Empty;
                                string timeOut = reader["TimeOut"] != DBNull.Value ? ConvertTo12HourFormat((TimeSpan)reader["TimeOut"]) : string.Empty;

                                dataAccessLogs.Rows.Add(
                                    i,
                                    reader["AL_Id"].ToString(),
                                    reader["User"].ToString(),
                                    reader["Date"] != DBNull.Value ? ((DateTime)reader["Date"]).ToShortDateString() : string.Empty,
                                    timeIn,
                                    timeOut,
                                    reader["Action"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ConvertTo12HourFormat(TimeSpan time)
        {
            string period = time.Hours >= 12 ? "PM" : "AM";
            int hour = time.Hours % 12;
            hour = hour == 0 ? 12 : hour;
            return $"{hour:D2}:{time.Minutes:D2} {period}";
        }

        private void btnALClear_Click(object sender, EventArgs e)
        {
            dataAccessLogs.Rows.Clear();
            dtALFrom.Value = DateTime.Now;
            dtALto.Value = DateTime.Now;
        }

        private void dataAccessLogs_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataAccessLogs.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataAccessLogs.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
        }

        private void btnALPrint_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            string param = "From : " + dtALFrom.Value.ToString("yyyy-MM-dd") + " To : " + dtALto.Value.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM AccessLogs WHERE Date BETWEEN @FromDate AND @ToDate";
            rep.LoadAccessLogs(sql, param, dtALFrom.Value.Date, dtALto.Value.Date);
            rep.ShowDialog();
        }

        private void tbQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void materialLabel38_Click(object sender, EventArgs e)
        {

        }
    }
}
