using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace project_akhir_pcc
{
    internal class koneksi
    {
        public SqlConnection Getconn()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data source = KHELVIN-AGATHA-; Initial Catalog= pemiluu; Integrated security= true";
            return conn;
        }
    }
}
