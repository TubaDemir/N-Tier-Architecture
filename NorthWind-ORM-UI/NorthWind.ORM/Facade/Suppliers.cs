using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.ORM.Facade
{
    public class Suppliers
    {
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("listSuppliers", Tools.baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}
