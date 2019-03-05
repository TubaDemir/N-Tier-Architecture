using NorthWind.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.ORM.Facade
{
    public class Products
    {
        
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("listProducts", Tools.baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Insert(Product p)
        {
            SqlCommand cmd = new SqlCommand("insertProduct", Tools.baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@prodName", p.ProductName);
            cmd.Parameters.AddWithValue("@unitPrice", p.UnitPrice);
            cmd.Parameters.AddWithValue("@unitsInStock", p.UnitsInStock);
            cmd.Parameters.AddWithValue("@CategoryID", p.CategoryID);
            cmd.Parameters.AddWithValue("@SupplierID", p.SupplierID);

            //if (cmd.Connection.State != ConnectionState.Open)
            //    cmd.Connection.Open();
            //int affected = cmd.ExecuteNonQuery();
            //if (cmd.Connection.State != ConnectionState.Closed)
            //    cmd.Connection.Close();
            //return (affected > 0);
            return Tools.ExecuteNonQuery(cmd);
        }

    }
}
