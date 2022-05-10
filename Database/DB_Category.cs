using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_App_1_Binary_Semantics.Database
{
    public static class DB_Category
    {
        static SqlConnection My_Connection = null;
        internal static SqlConnection conn()
        {
            try
            {
                if (My_Connection == null)
                {
                    My_Connection = new SqlConnection("Data Source=DESKTOP-N2MSQ1H;Initial Catalog=DucatTraining;Integrated Security=True");
                    My_Connection.Open();
                }
                if (My_Connection.State == ConnectionState.Closed)
                {
                    My_Connection.Open();
                }
                return My_Connection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}