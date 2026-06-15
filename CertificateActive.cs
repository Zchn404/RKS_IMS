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
    public partial class CertificateActive : MaterialForm
    {
        string FullName;
        string Date;
        public CertificateActive()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void CertificateActive_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public void EmployeeDetails(string FullName, string Date)
        {
            this.FullName = FullName;

            try
            {
                DateTime parsedDate;
                if (!DateTime.TryParse(Date, out parsedDate))
                {
                    MessageBox.Show("Invalid date format.");
                    return; 
                }

                string formattedDate = parsedDate.ToString("MMM dd, yyyy");

                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = CentralizedPathHelper.GetReportPath(@"CertActive.rdlc");
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();

                ReportParameter fullname = new ReportParameter("fullname", FullName);
                ReportParameter date = new ReportParameter("date", formattedDate); 

                reportViewer1.LocalReport.SetParameters(fullname);
                reportViewer1.LocalReport.SetParameters(date);

                rptDS = new ReportDataSource("RKS_InventoryDataSet", ds.Tables["User"]);
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
        private void CertificateActive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
