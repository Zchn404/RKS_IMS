using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RKS_Inventory
{
    public static class CentralizedPathHelper
    {
        public static string GetReportPath(string relativePath)
        {
            return Path.Combine(Application.StartupPath, @"C:\Users\Legion\Downloads\RKS IMS\RKS IMS\RKS_Inventory\RKS_Inventory", relativePath);
        }
    }
}
