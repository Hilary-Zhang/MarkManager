using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelper
    {
        private static SqlConnection conn;

        public static void connect(String connectionString)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
        }

        public static int execute(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }

        public static SqlDataReader query(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteReader();
        }

        public static int execute(String sql, params SqlParameter[] sqlParams)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Clear();
            foreach (SqlParameter param in sqlParams)
            {
                cmd.Parameters.Add(param);
            }
            return cmd.ExecuteNonQuery();
        }

        public static SqlDataReader query(String sql,params SqlParameter[] sqlParams)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Clear();
            foreach(SqlParameter param in sqlParams)
            {
                cmd.Parameters.Add(param);
            }
            return cmd.ExecuteReader();
        }
    }
}
