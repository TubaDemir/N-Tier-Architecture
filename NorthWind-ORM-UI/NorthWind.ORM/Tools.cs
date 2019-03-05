using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NorthWind.ORM
{
    public class Tools
    {
        // UI projesinde App.config icerisine baglanti parametresi eklenir.
        internal static SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        
        internal static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                int affected = cmd.ExecuteNonQuery();
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
                return (affected > 0);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
    }
}
