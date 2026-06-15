using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Reporting.WinForms;
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
    public partial class Receipt : MaterialForm
    {
        Staff staff;
        public Receipt(Staff staff)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey500, Accent.Green700, TextShade.WHITE);
            this.staff = staff;
            this.KeyPreview = true;
        }

        private void Receipt_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
        public void LoadReceipt(string pcash, string pchange)
        {
            ReportDataSource rptDataSourece;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"Receipt.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();

                SqlConnection cn = DatabaseManager.GetConnection();
                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand("SELECT Cart_Id, TransactionNo, Name, Price, Quantity, Discount, Total, Date, Status, Product_Id FROM vwCart WHERE TransactionNo LIKE '" + staff.lblTransNo.Text + "'", cn);
                da.Fill(ds.Tables["Cart"]);
                cn.Close();

                ReportParameter Vatable = new ReportParameter("Vatable", staff.lblVatable.Text);
                ReportParameter Vat = new ReportParameter("Vat", staff.lblVat.Text);
                ReportParameter Discount = new ReportParameter("Discount", staff.lblDiscount.Text);
                ReportParameter Total = new ReportParameter("Total", staff.lblDisplayTotal.Text);
                ReportParameter Cash = new ReportParameter("Cash", pcash);
                ReportParameter Change = new ReportParameter("Change", pchange);
                ReportParameter Transaction = new ReportParameter("Transaction", "SI #: " + staff.lblTransNo.Text);
                ReportParameter Cashier = new ReportParameter("Cashier", staff.UserSA);

                reportViewer1.LocalReport.SetParameters(Vatable);
                reportViewer1.LocalReport.SetParameters(Vat);
                reportViewer1.LocalReport.SetParameters(Discount);
                reportViewer1.LocalReport.SetParameters(Total);
                reportViewer1.LocalReport.SetParameters(Cash);
                reportViewer1.LocalReport.SetParameters(Change);
                reportViewer1.LocalReport.SetParameters(Transaction);
                reportViewer1.LocalReport.SetParameters(Cashier);

                rptDataSourece = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["Cart"]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Receipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
