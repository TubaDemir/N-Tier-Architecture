using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using NorthWind.ORM.Entity;

namespace NorthWind.ORM.Facade
{
    public class Categories
    {
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("listCategories", Tools.baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Insert(Category c)
        {
            SqlCommand cmd = new SqlCommand("insertCategory", Tools.baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@catName", c.CategoryName);
            cmd.Parameters.AddWithValue("@catDesc", c.Description);
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            int affected = cmd.ExecuteNonQuery();
            if (cmd.Connection.State != ConnectionState.Closed)
                cmd.Connection.Close();
            return (affected > 0);
//return Tools.ExecuteNonQuery(cmd);
        }
    }
}
