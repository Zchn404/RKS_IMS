using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKS_Inventory
{
    public static class DatabaseManager
    {
        private static readonly string connectionString = "Data Source=DESKTOP-KTLM4T1\\SQLEXPRESS;Initial Catalog=RKS_Inventory;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
