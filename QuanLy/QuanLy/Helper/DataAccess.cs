using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace QuanLy.Helper
{
    class DataAccess
    {
        static SqlConnection con;
        public static void SetupConnection(string str)
        {
            try
            {
                con = new SqlConnection(str);
            }
            catch (Exception ex)
            {

            }
        }
        public static DataTable ExecQuery(string query, params SqlParameter[] sp)
        {
            con.Open();
            SqlDataAdapter da;
            if (query.Contains(" "))
            {
                da = new SqlDataAdapter(query, con);
            }
            else
            {
                SqlCommand sc = new SqlCommand(query, con);
                sc.CommandType = CommandType.StoredProcedure;
                if (sp.Length > 0)
                {
                    foreach (SqlParameter p in sp)
                    {
                        sc.Parameters.Add(p);
                    }
                }
                da = new SqlDataAdapter(sc);
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static void ExecNonQuery(string command, params SqlParameter[] sp)
        {
            con.Open();
            SqlCommand sc = new SqlCommand(command, con);
            if (command.Contains(" "))
            {
                sc.CommandType = CommandType.Text;
            }
            else
            {
                sc.CommandType = CommandType.StoredProcedure;
                if (sp.Length > 0)
                {
                    foreach (SqlParameter p in sp)
                    {
                        sc.Parameters.Add(p);
                    }
                }
            }
            sc.ExecuteNonQuery();
            con.Close();
        }
    }
}
