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
using static Google.Protobuf.Reflection.UninterpretedOption.Types;

namespace RKS_Inventory
{
    public partial class Staff : MaterialForm
    {
        SqlConnection cn = DatabaseManager.GetConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private Login login;
        public string _pass;
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
        public Staff()
        {
            InitializeComponent();
            InitializeDataGridView(dataDeliveries);
            var themeManager = ThemeManager.Instance;
            themeManager.TheMaterialSkinManager.AddFormToManage(this);
            themeManager.SetTheme(MaterialSkinManager.Themes.LIGHT);
            GetRefeNo();
            ReferenceNo();
            GetTranNo();          
            LoadCart();
            LoadSold();
            LoadCSupplier();
            LoadDeliveries();           
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
        public string TransNo
        {
            get { return lblTransNo.Text; }
            set { lblTransNo.Text = value; }
        }
        public string labelUser
        {
            get { return lblUser.Text; }
            set { lblUser.Text = value; }
        }
        public string labelRole
        {
            get { return lblRole.Text; }
            set { lblRole.Text = value; }
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
        public void LoadCart()
        {
            try
            {
                Boolean hascart = false;
                int i = 0;
                int total = 0;
                int discount = 0;
                dataStaff.Rows.Clear();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    string selectSql = @"SELECT c.Cart_Id, i.Name, c.Price, c.Quantity, c.Discount, c.Total, c.Product_Id
                                 FROM Cart c
                                 INNER JOIN Inventory i ON c.Product_Id = i.Product_Id
                                 WHERE c.TransactionNo = @TransNo AND c.Status = 'Pending'";

                    using (SqlCommand cm = new SqlCommand(selectSql, cn))
                    {
                        cm.Parameters.AddWithValue("@TransNo", lblTransNo.Text);

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                i++;
                                total += int.Parse(dr["Total"].ToString());
                                discount += int.Parse(dr["Discount"].ToString());

                                dataStaff.Rows.Add(
                                    i,
                                    dr["Cart_Id"].ToString(),
                                    dr["Name"].ToString(),
                                    dr["Price"].ToString(),
                                    dr["Quantity"].ToString(),
                                    dr["Discount"].ToString(),
                                    int.Parse(dr["Total"].ToString()).ToString("###,###,##0"),
                                    dr["Product_Id"].ToString()
                                );

                                hascart = true;
                            }
                        }
                    }
                }
                lblSalesTotal.Text = total.ToString("###,###,##0");
                lblDiscount.Text = discount.ToString("###,###,##0");
                GetCartTotal();
                btnClear.Enabled = hascart;
                btnPayment.Enabled = hascart;
                btnDiscount.Enabled = hascart;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        
        public void GetCartTotal()
        {
            double discount = double.Parse(lblDiscount.Text);
            double sales = double.Parse(lblSalesTotal.Text); 
            double vat = sales * 0.12;
            double vatable = sales - vat;

            lblVat.Text = vat.ToString("###,###,##0");
            lblVatable.Text = vatable.ToString("###,###,##0");
            lblDisplayTotal.Text = sales.ToString("###,###,##0");
        }
        public void GetTranNo()
        {
            string sdate = DateTime.Now.ToString("yyyyMMdd");
            string transno;
            int count;

            try
            {
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT TOP 1 TransactionNo FROM Cart WHERE TransactionNo LIKE @Date ORDER BY Cart_Id DESC", cn))
                    {
                        cm.Parameters.AddWithValue("@Date", sdate + "%");
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read() && dr.HasRows)
                            {
                                transno = dr[0].ToString();
                                count = int.Parse(transno.Substring(8, 4));
                                lblTransNo.Text = sdate + (count + 1).ToString("D4");
                            }
                            else
                            {
                                transno = sdate + "1001";
                                lblTransNo.Text = transno;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        public void GetRefeNo()
        {
            /*Random rnd = new Random();
            lblReference.Text = rnd.Next().ToString();*/

            // Get the current date in the format of yyyyMMdd (year, month, day)
            string datePart = DateTime.Now.ToString("yyyyMMdd");

            // Generate a random 4-digit number
            Random random = new Random();
            int randomDigits = random.Next(0000, 9999);

            // Combine the date and the random number
            string randomNumber = $"{datePart}{randomDigits}";

            // Display the result (e.g., in a label or textbox)
            lblReference.Text = randomNumber;
        }
        public void ReferenceNo()
        {
            /*Random rnd = new Random();
            lblReference.Text = rnd.Next(1000, 8999).ToString(); */

            // Get the current date in the format of yyyyMMdd (year, month, day)
            string datePart = DateTime.Now.ToString("yyyyMMdd");

            // Generate a random 4-digit number
            Random randomizer = new Random();
            int randomDigits = randomizer.Next(1000, 9999);

            // Combine the date and the random number
            string randomNumber1 = $"{datePart}{randomDigits}";

            // Display the result (e.g., in a label or textbox)
            lblRefNo.Text = randomNumber1;
        }
        public void Clear()
        {
            dtStockIn.Value = DateTime.Now;
            GetRefeNo();
        }
        public void Clear1()
        {
            lblProductDet.Text = "";
            tbQty.Clear();
            tbRemarks.Clear();
            cbAction.Text = "";
            ReferenceNo();
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
        //                    cbSupp.DataSource = dataTable;
        //                    cbSupp.DisplayMember = "Supplier";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //}
        public void LoadAdjustment()
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
                    SortByIdColumn();
                }
            }
        }
        private void SortByIdColumn()
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
        
        private void Staff_Load(object sender, EventArgs e)
        {
            this.inventoryTableAdapter.Fill(this.rKS_InventoryDataSet.Inventory);
            this.stocksTableAdapter.Fill(this.rKS_InventoryDataSet.Stocks);
            Noti();
            dataStocks.DataSource = null;
        }
        void Search(string text = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                dataAdjustment.DataSource = Query("SELECT * FROM Inventory");
            }
            else
            {
                dataAdjustment.DataSource = Query("SELECT * FROM Inventory where Product_Id LIKE '%{0}%' OR Name LIKE '%{0}%' OR Brand LIKE '%{0}%' OR Category LIKE '%{0}%'", text);
                dataAdjustment.ClearSelection();
            }
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

        private void btnLight_Click(object sender, EventArgs e)
        {
            isDarkMode = false;
            btnDark.BringToFront();
            ThemeManager.Instance.SetTheme(MaterialSkinManager.Themes.LIGHT);
            dataStocks.BackgroundColor = Color.White;
            dataStocks.DefaultCellStyle.BackColor = Color.White;
            dataStocks.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataAdjustment.BackgroundColor = Color.White;
            dataAdjustment.DefaultCellStyle.BackColor = Color.White;
            dataAdjustment.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataStaff.BackgroundColor = Color.White;
            dataStaff.DefaultCellStyle.BackColor = Color.White;
            dataStaff.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataDailyS.BackgroundColor = Color.White;
            dataDailyS.DefaultCellStyle.BackColor = Color.White;
            dataDailyS.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataDeliveries.BackgroundColor = Color.White;
            dataDeliveries.DefaultCellStyle.BackColor = Color.White;
            dataDeliveries.RowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnDark_Click(object sender, EventArgs e)
        {
            isDarkMode = true;
            btnLight.BringToFront();
            ThemeManager.Instance.SetTheme(MaterialSkinManager.Themes.DARK);
            dataStocks.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataStocks.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataStocks.RowsDefaultCellStyle.ForeColor = Color.White;
            dataStocks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);        
            dataAdjustment.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataAdjustment.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataAdjustment.RowsDefaultCellStyle.ForeColor = Color.White;
            dataAdjustment.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataStaff.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataStaff.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataStaff.RowsDefaultCellStyle.ForeColor = Color.White;
            dataStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataDailyS.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataDailyS.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataDailyS.RowsDefaultCellStyle.ForeColor = Color.White;
            dataDailyS.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataDeliveries.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataDeliveries.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataDeliveries.RowsDefaultCellStyle.ForeColor = Color.White;
            dataDeliveries.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            btnDSPrint.BackColor = Color.White;
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void tbSearchSA_TextChanged(object sender, EventArgs e)
        {
            Search(tbSearchSA.Text);
        }

        private void dataStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataStocks.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Remove this item?", "In Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM Stocks WHERE Stock_Id='" + dataStocks.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item has been successfully removed", "In Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataStocks();
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
                    lblProductDet.Text = $"{row.Cells[1].Value}  {row.Cells[2].Value}  {row.Cells[3].Value}";

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

                    lblprodId.Text = row.Cells["Product_IdSA"].Value?.ToString() ?? string.Empty;
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
        //    dr.Close();
        //    cn.Close();
        //}


        private void ShowWarning(string message, Control focusControl = null)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focusControl?.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        int qty;
        string id;
        string price;
        private int _quantity;
        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StaffProduct staffproduct = new StaffProduct(this);
            staffproduct.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove all items from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cm = new SqlCommand("DELETE FROM Cart WHERE TransactionNo like'" + lblTransNo.Text + "'", cn);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("All items has been successfully remove", "Remove item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCart();
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            Discount discount = new Discount(this);
            discount.labelId = id;
            discount.TotalPrice = price;
            discount.ShowDialog();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment(this);
            payment.Sale = lblDisplayTotal.Text;
            payment.ShowDialog();
        }
        public void LoadSold()
        {
            int rowIndex = 0;
            int totalAmount = 0;
            dataDailyS.Rows.Clear();

            string query = @"SELECT c.Cart_Id, c.TransactionNo, p.Name, c.Price, c.Quantity, c.Discount, c.Total, c.Product_Id, c.Cashier, c.Date FROM Cart c INNER JOIN Inventory p ON c.Product_Id = p.Product_Id WHERE c.Status = 'Sold' AND c.Date = @startDate";

            using (SqlConnection cn = DatabaseManager.GetConnection())
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        DateTime currentDate = DateTime.Today;

                        cmd.Parameters.AddWithValue("@startDate", currentDate.Date);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rowIndex++;
                                totalAmount += reader.GetInt32(reader.GetOrdinal("Total"));
                                dataDailyS.Rows.Add(
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
            lblDSTotal.Text = totalAmount.ToString("###,###,##0");
        }

        private void btnDSPrint_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            DateTime currentDate = DateTime.Today;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            string query = $"SELECT Cart_Id, TransactionNo, Name, Price, Quantity, Discount, Total FROM vwCart WHERE Status = 'Sold' AND Date = '{formattedDate}'";
            rep.LoadDailyReport(query, lblUserSA.Text);
            rep.ShowDialog();
        }

        private void dataDailyS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataDailyS.Columns[e.ColumnIndex].Name;
            if (colName == "Cancel")
            {
                CancelOrder cancel = new CancelOrder(this);
                cancel.CartId = dataDailyS.Rows[e.RowIndex].Cells[1].Value.ToString();
                cancel.TransactionNo = dataDailyS.Rows[e.RowIndex].Cells[2].Value.ToString();
                cancel.CartName = dataDailyS.Rows[e.RowIndex].Cells[3].Value.ToString();
                cancel.CartPrice = dataDailyS.Rows[e.RowIndex].Cells[4].Value.ToString();
                cancel.CartQuantity = dataDailyS.Rows[e.RowIndex].Cells[5].Value.ToString();
                cancel.CartDiscount = dataDailyS.Rows[e.RowIndex].Cells[6].Value.ToString();
                cancel.CartTotal = dataDailyS.Rows[e.RowIndex].Cells[7].Value.ToString();
                cancel.CartProductId = dataDailyS.Rows[e.RowIndex].Cells[8].Value.ToString();
                cancel.UserVoid = lblUserSA.Text;
                cancel.VoidBy = lblUserSA.Text;
                cancel.ShowDialog();
            }
        }

        private void btnSBrowse_Click(object sender, EventArgs e)
        {
            ProductStockInStaff productStockStaff = new ProductStockInStaff(this);
            productStockStaff.Show();
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataStocks.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to save this records?", "In Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataStocks.Rows.Count; i++)
                        {
                            cn.Open();
                            cm = new SqlCommand("UPDATE Inventory SET Quantity = Quantity + " + int.Parse(dataStocks.Rows[i].Cells[3].Value.ToString()) + " WHERE Product_Id LIKE '" + dataStocks.Rows[i].Cells[7].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();

                            cn.Open();
                            cm = new SqlCommand("UPDATE Stocks SET Quantity = Quantity + " + int.Parse(dataStocks.Rows[i].Cells[3].Value.ToString()) + ", Status='Done' WHERE Stock_Id LIKE '" + dataStocks.Rows[i].Cells[0].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }
                        Clear();
                        LoadDataStocks();
                        LoadAdjustment();
                        dataStocks.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "In Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                LoadAdjustment();
                LoadDataStocks();
                dataStocks.DataSource = null;
                Clear1();
                btnSaveSA.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnChange_Click(object sender, EventArgs e)
        //{
        //    if (tbCurrent.Text != _pass)
        //    {
        //        MessageBox.Show("Current password did not match!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else if (tbCurrent.Text == _pass)
        //    {
        //        tbNew.Enabled = true;
        //        tbNewRe.Enabled = true;
        //    }

        //    else if (tbNew.Text != tbNewRe.Text)
        //    {
        //        MessageBox.Show("Confirm new password did not match!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else if (string.IsNullOrEmpty(tbNew.Text))
        //    {
        //        MessageBox.Show("Please Input!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else if (string.IsNullOrEmpty(tbNewRe.Text))
        //    {
        //        MessageBox.Show("Please Input!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    try
        //    {
        //        using (SqlConnection conn = DatabaseManager.GetConnection())
        //        {
        //            conn.Open();

        //            string query = "UPDATE [User] SET Password = @NewPassword WHERE Username = @Username";

        //            using (SqlCommand comm = new SqlCommand(query, conn))
        //            {
        //                comm.Parameters.AddWithValue("@NewPassword", tbNew.Text);
        //                comm.Parameters.AddWithValue("@Username", lblUser1.Text);

        //                int rowsAffected = comm.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    MessageBox.Show("Password has been successfully changed!", "Changed Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    tbCurrent.Clear();
        //                    tbNew.Clear();
        //                    tbNewRe.Clear();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Password change failed. User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void dataStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string colName = dataStaff.Columns[e.ColumnIndex].Name;

            int _quantity = 1;

            using (SqlConnection cn = DatabaseManager.GetConnection())
            {
                cn.Open();

                if (colName == "Delete1")
                {
                    if (MessageBox.Show("Remove this item?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string cartId = dataStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Cart WHERE Cart_Id = @CartId", cn))
                        {
                            cmd.Parameters.AddWithValue("@CartId", cartId);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Items have been successfully removed.", "Remove item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCart();
                    }
                }
                else if (colName == "colAdd")
                {
                    string productid = dataStaff.Rows[e.RowIndex].Cells[7].Value.ToString();
                    int qtyAvailable;

                    using (SqlCommand cmd = new SqlCommand("SELECT SUM(Quantity) as qty FROM Inventory WHERE Product_Id = @Product_Id GROUP BY Product_Id", cn))
                    {
                        cmd.Parameters.AddWithValue("@Product_Id", productid);
                        qtyAvailable = (int)cmd.ExecuteScalar();
                    }

                    int qtyInCart = int.Parse(dataStaff.Rows[e.RowIndex].Cells[4].Value.ToString());
                    if (qtyInCart < qtyAvailable)
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Cart SET Quantity = Quantity + @Quantity WHERE TransactionNo = @TransactionNo AND Product_Id = @Product_Id", cn))
                        {
                            cmd.Parameters.AddWithValue("@Quantity", _quantity);
                            cmd.Parameters.AddWithValue("@TransactionNo", lblTransNo.Text);
                            cmd.Parameters.AddWithValue("@Product_Id", productid);
                            cmd.ExecuteNonQuery();
                        }
                        LoadCart();
                    }
                    else
                    {
                        MessageBox.Show("Remaining quantity on hand is " + qtyAvailable + "!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (colName == "colReduce")
                {
                    string productId = dataStaff.Rows[e.RowIndex].Cells[7].Value.ToString();
                    int qtyInCart;

                    using (SqlCommand cmd = new SqlCommand("SELECT Quantity FROM Cart WHERE TransactionNo = @TransactionNo AND Product_Id = @Product_Id", cn))
                    {
                        cmd.Parameters.AddWithValue("@TransactionNo", lblTransNo.Text);
                        cmd.Parameters.AddWithValue("@Product_Id", productId);
                        qtyInCart = (int)cmd.ExecuteScalar();
                    }

                    if (qtyInCart > _quantity)
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Cart SET Quantity = Quantity - @Quantity WHERE TransactionNo = @TransactionNo AND Product_Id = @Product_Id", cn))
                        {
                            cmd.Parameters.AddWithValue("@Quantity", _quantity);
                            cmd.Parameters.AddWithValue("@TransactionNo", lblTransNo.Text);
                            cmd.Parameters.AddWithValue("@Product_Id", productId);
                            cmd.ExecuteNonQuery();
                        }
                        LoadCart();
                    }
                    else
                    {
                        MessageBox.Show("Cannot reduce. Quantity in cart is only " + qtyInCart + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dataStaff_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataStaff.CurrentRow.Index;
            id = dataStaff[1, i].Value.ToString();
            price = dataStaff[6, i].Value.ToString();
        }
        public string User
        {
            get { return lblUserSA.Text; }
            set { lblUserSA.Text = value; }
        }
        public string Role
        {
            get { return lblRole.Text; }
            set { lblRole.Text = value; }
        }
        private void btnSystemLock_Click(object sender, EventArgs e)
        {
            this.Hide();
            SystemLock slock = new SystemLock(this);
            slock.User = lblUserSA.Text;
            slock.Role = lblRole.Text;
            slock.UserSA = lblUserSA.Text;
            slock.ShowDialog();
        }

        private void cbSupp_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void dataDeliveries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataDeliveries.Columns[e.ColumnIndex].Name;
            if (colName == "List1")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataDeliveries.Rows[e.RowIndex];

                    string referenceNo = selectedRow.Cells["SO_No"].Value.ToString();

                    SupplierListStaff slitstaff = new SupplierListStaff(this, referenceNo);
                    slitstaff.ShowDialog();
                }
                //SupplierList suplist = new SupplierList(this, referenceNo);
                //suplist.RefNo = dataDeliveries.Rows[e.RowIndex].Cells[4].Value.ToString();
                //suplist.ShowDialog();
            }
            else if (colName == "Edit6")
            {
                EditOrdersStaff edorderstaff = new EditOrdersStaff(this);

                edorderstaff.SOStatus = dataDeliveries.Rows[e.RowIndex].Cells[8].Value.ToString();
                edorderstaff.SONo = dataDeliveries.Rows[e.RowIndex].Cells[4].Value.ToString();
                edorderstaff.SORb = lblUserSA.Text;
                edorderstaff.ShowDialog();
            }
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

        private void dataDailyS_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataDailyS.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataDailyS.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
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

        private void dataStaff_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Even rows - set color to green
                dataStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGreen;
            }
            else
            {
                // Odd rows - set color to white or any other color
                dataStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            }
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
    }
}
