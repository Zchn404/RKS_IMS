using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Reporting.WinForms;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RKS_Inventory
{
    public partial class Report : MaterialForm
    {
        SqlConnection cn = DatabaseManager.GetConnection();
        public Report()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
        public void LoadInventory(string sql)
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"Inventorylist.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();
                SqlConnection cn = DatabaseManager.GetConnection();
                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                da.SelectCommand = new SqlCommand(sql, cn);
                da.Fill(ds.Tables["Inventory"]);
                cn.Close();


                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["Inventory"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadStockInHistory(string sql, string param, DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"StockInHistory.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddTicks(-1));

                        da.SelectCommand = cmd;
                        da.Fill(ds.Tables["StockInHistory"]);
                    }
                }

                ReportParameter pDate = new ReportParameter("pDate", param);

                reportViewer1.LocalReport.SetParameters(pDate);
                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["StockInHistory"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadDailyReport(string sql, string cashier)
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"SoldReport.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();
                SqlConnection cn = DatabaseManager.GetConnection();
                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                da.SelectCommand = new SqlCommand(sql, cn);
                da.Fill(ds.Tables["Cart"]);
                cn.Close();

                ReportParameter Cashier = new ReportParameter("Cashier", cashier);

                reportViewer1.LocalReport.SetParameters(Cashier);

                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["Cart"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadSalesHistory(string sql, string param, DateTime startDate, DateTime endDate)
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"SoldItems.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                        cmd.Parameters.AddWithValue("@endDate", endDate.Date);

                        da.SelectCommand = cmd;
                        da.Fill(ds.Tables["Cart"]);
                    }
                }

                ReportParameter Date = new ReportParameter("Date", param);

                reportViewer1.LocalReport.SetParameters(Date);

                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["Cart"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadTopSelling(string sql, DateTime dateFrom, DateTime dateTo, string param, string header)
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"TopSelling.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, cn))
                        {
                            cmd.Parameters.AddWithValue("@DateFrom", dateFrom.Date);
                            cmd.Parameters.AddWithValue("@DateTo", dateTo.Date);

                            da.SelectCommand = cmd;
                            da.Fill(ds.Tables["TopSelling"]);
                        }
                    }
                }

                ReportParameter Date = new ReportParameter("Date", param);
                ReportParameter Header = new ReportParameter("Header", header);

                reportViewer1.LocalReport.SetParameters(Date);
                reportViewer1.LocalReport.SetParameters(Header);

                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["TopSelling"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadAdjustmentHistory(string sql, string param, DateTime startDate, DateTime endDate)
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"AdjustmentHistory.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                        cmd.Parameters.AddWithValue("@endDate", endDate.Date);

                        da.SelectCommand = cmd;
                        da.Fill(ds.Tables["Adjust"]);
                    }
                }

                ReportParameter Date = new ReportParameter("Date", param);

                reportViewer1.LocalReport.SetParameters(Date);

                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["Adjust"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "REPORT ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void LoadCancelledOrder(string sql, string param, DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"CancelledOrder.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                        da.SelectCommand = cmd;
                        da.Fill(ds.Tables["Cancel"]);
                    }
                }

                ReportParameter Date = new ReportParameter("Date", param);

                reportViewer1.LocalReport.SetParameters(Date);
                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["Cancel"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadOrders(string sql, string param, DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"Orders.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                        da.SelectCommand = cmd;
                        da.Fill(ds.Tables["SuppliersOrder"]);
                    }
                }

                ReportParameter Date = new ReportParameter("Date", param);

                reportViewer1.LocalReport.SetParameters(Date);
                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["SuppliersOrder"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadAccessLogs(string sql, string param, DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"AccessLogs.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection cn = DatabaseManager.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                        da.SelectCommand = cmd;
                        da.Fill(ds.Tables["SuppliersOrder"]);
                    }
                }

                ReportParameter Date = new ReportParameter("Date", param);

                reportViewer1.LocalReport.SetParameters(Date);
                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["SuppliersOrder"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
