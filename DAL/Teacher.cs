using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DAL
{
    public class Teacher
    {
        public static int checkPassword(String username,String password)
        {
            SqlDataReader reader = DBHelper.query("SELECT TOP 1 [id],[password] FROM [Teacher] WHERE name='" + username + "'");
            return reader.Read() && reader["password"].ToString() == password ? Convert.ToInt32(reader["id"]) : 0;
        }
    }
}
